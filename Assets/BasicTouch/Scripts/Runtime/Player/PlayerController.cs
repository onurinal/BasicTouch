using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Manager;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerProperties m_PlayerProperties;
        [SerializeField] private PlayerInputHandler m_PlayerInputHandler;
        [SerializeField] private Rigidbody m_Rigidbody;

        [Header("Interaction Settings")]
        [SerializeField] private SphereCollider m_SphereCollider;
        [SerializeField] private float m_InteractionRange;
        private List<IInteractable> m_currentInteractableList;
        private IInteractable m_currentInteractableToggle;

        private Vector3 m_movementDirection;
        private Camera m_mainCamera;

        private void Awake()
        {
            if (m_PlayerProperties == null)
            {
                Debug.LogWarning("PlayerProperties is null");
                return;
            }

            if (m_mainCamera == null)
            {
                m_mainCamera = Camera.main;
            }

            SetInteractionRange();
            m_currentInteractableList = new List<IInteractable>();
        }

        private void OnEnable()
        {
            EventManager.OnInteract += Interact;
        }

        private void OnDisable()
        {
            EventManager.OnInteract -= Interact;
        }

        private void Update()
        {
            CalculateMoveDirection();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void CalculateMoveDirection()
        {
            Vector2 inputDirection = m_PlayerInputHandler.MoveInput;

            Vector3 cameraForward = m_mainCamera.transform.forward;
            Vector3 cameraRight = m_mainCamera.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            m_movementDirection = (inputDirection.y * cameraForward + inputDirection.x * cameraRight).normalized;
        }

        private void Move()
        {
            if (m_Rigidbody == null)
            {
                Debug.LogWarning("Rigidbody is null");
                return;
            }

            Vector3 movement = m_movementDirection * m_PlayerProperties.MoveSpeed;
            m_Rigidbody.linearVelocity = new Vector3(movement.x, m_Rigidbody.linearVelocity.y, movement.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            var currentInteract = other.GetComponent<IInteractable>();

            if (currentInteract != null)
            {
                if (!m_currentInteractableList.Contains(currentInteract))
                {
                    m_currentInteractableList.Add(currentInteract);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var currentInteract = other.GetComponent<IInteractable>();
            if (currentInteract != null)
            {
                if (m_currentInteractableList.Contains(currentInteract))
                {
                    m_currentInteractableList.Remove(currentInteract);
                }
            }
        }

        private void Interact()
        {
            if (m_currentInteractableList.Count > 0)
            {
                m_currentInteractableToggle = FindClosestInteractable();
                m_currentInteractableToggle.Interact();
            }
        }

        private IInteractable FindClosestInteractable()
        {
            if (m_currentInteractableList.Count == 1)
            {
                return m_currentInteractableList[0];
            }
            else
            {
                float closestDistance = float.MaxValue;
                IInteractable closestInteractableToggle = null;
                foreach (IInteractable interactable in m_currentInteractableList)
                {
                    if (interactable != null)
                    {
                        var newDistance = Vector3.Distance(transform.position, interactable.GetTransform().position);
                        if (closestDistance > newDistance)
                        {
                            closestDistance = newDistance;
                            closestInteractableToggle = interactable;
                        }
                    }
                }

                return closestInteractableToggle;
            }
        }

        private void SetInteractionRange()
        {
            m_SphereCollider.radius = m_InteractionRange;
        }
    }
}