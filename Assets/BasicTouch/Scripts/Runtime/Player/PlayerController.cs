using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Event;
using BasicTouch.Runtime.UI;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Manages the player movement and interaction system
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Fields

        [Header("References")]
        [SerializeField] private PlayerProperties m_PlayerData;
        [SerializeField] private PlayerInputHandler m_PlayerInputHandler;
        [SerializeField] private Rigidbody m_Rigidbody;

        [Header("Interaction Settings")]
        [SerializeField] private SphereCollider m_SphereCollider;
        [SerializeField] private float m_InteractionRange;

        private List<IInteractable> m_CurrentInteractableList;
        private IInteractable m_CurrentInteractable;
        private Vector3 m_MovementDirection;
        private Camera m_MainCamera;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_PlayerData == null)
            {
                Debug.LogError("[PlayerController] PlayerProperties is null. Please assign it in the Inspector.");
                return;
            }

            if (m_SphereCollider == null)
            {
                Debug.LogError($"{nameof(SphereCollider)} reference is missing on {gameObject.name}!");
            }

            if (m_MainCamera == null)
            {
                m_MainCamera = Camera.main;

                if (m_MainCamera == null)
                {
                    Debug.LogError("[PlayerController] Main camera not found in the scene.");
                    return;
                }
            }

            SetInteractionRange();
            m_CurrentInteractableList = new List<IInteractable>();
        }

        private void OnEnable()
        {
            EventManager.OnInteract += HandleInteract;
        }

        private void OnDisable()
        {
            EventManager.OnInteract -= HandleInteract;
        }

        private void Update()
        {
            CalculateMoveDirection();
            UpdateClosestInteractable();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable currentInteract))
            {
                if (!m_CurrentInteractableList.Contains(currentInteract))
                {
                    m_CurrentInteractableList.Add(currentInteract);
                    m_CurrentInteractable = GetClosestInteractable();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractable currentInteract))
            {
                if (m_CurrentInteractableList.Contains(currentInteract))
                {
                    m_CurrentInteractableList.Remove(currentInteract);

                    if (m_CurrentInteractableList.Count == 0)
                    {
                        m_CurrentInteractable = null;
                        HideInteractionText();
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void CalculateMoveDirection()
        {
            Vector2 inputDirection = m_PlayerInputHandler.MoveInput;

            Vector3 cameraForward = m_MainCamera.transform.forward;
            Vector3 cameraRight = m_MainCamera.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            m_MovementDirection = (inputDirection.y * cameraForward + inputDirection.x * cameraRight).normalized;
        }

        private void Move()
        {
            if (m_Rigidbody == null)
            {
                return;
            }

            Vector3 movement = m_MovementDirection * m_PlayerData.MoveSpeed;
            m_Rigidbody.linearVelocity = new Vector3(movement.x, m_Rigidbody.linearVelocity.y, movement.z);
        }


        private void HandleInteract()
        {
            if (m_CurrentInteractable == null)
            {
                return;
            }

            m_CurrentInteractable.Interact();
            if (m_CurrentInteractable is IInteractableInstant)
            {
                m_CurrentInteractableList.Remove(m_CurrentInteractable);
                HideInteractionText();
            }
            else
            {
                ShowInteractionText();
            }
        }

        private IInteractable GetClosestInteractable()
        {
            if (m_CurrentInteractableList.Count == 0)
            {
                return null;
            }

            if (m_CurrentInteractableList.Count == 1)
            {
                return m_CurrentInteractableList[0];
            }

            float closestDistance = float.MaxValue;
            IInteractable closestInteractable = null;

            foreach (IInteractable interactable in m_CurrentInteractableList)
            {
                if (interactable == null)
                {
                    continue;
                }

                var newDistance = Vector3.Distance(transform.position, interactable.GetTransform().position);
                if (closestDistance > newDistance)
                {
                    closestDistance = newDistance;
                    closestInteractable = interactable;
                }
            }

            return closestInteractable;
        }

        private void UpdateClosestInteractable()
        {
            IInteractable closestInteractable = GetClosestInteractable();

            if (closestInteractable == null)
            {
                m_CurrentInteractable = null;
                HideInteractionText();
                return;
            }

            if (closestInteractable != m_CurrentInteractable)
            {
                m_CurrentInteractable = closestInteractable;
            }

            ShowInteractionText();
        }

        private void ShowInteractionText()
        {
            if (m_CurrentInteractable != null && UIManager.Instance != null)
            {
                UIManager.Instance.ShowInteractionText(m_CurrentInteractable.GetInteractText());
            }
        }

        private void HideInteractionText()
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.HideInteractionText();
            }
        }

        private void SetInteractionRange()
        {
            m_SphereCollider.radius = m_InteractionRange;
        }
    }

    #endregion
}