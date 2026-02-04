using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Event;
using BasicTouch.Runtime.UI;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Detects nearby interactable objects and manages interaction logic.
    /// </summary>
    public class PlayerInteractionDetector : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Interaction Settings")]
        [SerializeField] private SphereCollider m_SphereCollider;
        [SerializeField] private float m_InteractionRange = 2f;

        #endregion

        #region Private Fields

        private readonly List<IInteractable> m_CurrentInteractables = new();
        private IInteractable m_CurrentInteractable;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_SphereCollider == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerInteractionDetector)}: SphereCollider reference is missing.",
                    this);
                enabled = false;
                return;
            }

            m_SphereCollider.isTrigger = true;
            m_SphereCollider.radius = m_InteractionRange;
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
            UpdateClosestInteractable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            if (!m_CurrentInteractables.Contains(interactable))
            {
                m_CurrentInteractables.Add(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            if (m_CurrentInteractables.Remove(interactable))
            {
                if (m_CurrentInteractables.Count == 0)
                {
                    m_CurrentInteractable = null;
                    HideInteractionText();
                }
            }
        }

        #endregion

        #region Methods

        private void HandleInteract()
        {
            if (m_CurrentInteractable == null)
                return;

            m_CurrentInteractable.Interact();

            if (m_CurrentInteractable is IInteractableInstant)
            {
                m_CurrentInteractables.Remove(m_CurrentInteractable);
                m_CurrentInteractable = null;
                HideInteractionText();
            }
            else
            {
                ShowInteractionText();
            }
        }

        private void UpdateClosestInteractable()
        {
            IInteractable closest = GetClosestInteractable();

            if (closest == null)
            {
                m_CurrentInteractable = null;
                HideInteractionText();
                return;
            }

            if (closest != m_CurrentInteractable)
            {
                m_CurrentInteractable = closest;
                ShowInteractionText();
            }
        }

        private IInteractable GetClosestInteractable()
        {
            float closestDistance = float.MaxValue;
            IInteractable closest = null;

            foreach (IInteractable interactable in m_CurrentInteractables)
            {
                if (interactable == null)
                    continue;

                float distance = Vector3.Distance(
                    transform.position,
                    interactable.GetTransform().position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = interactable;
                }
            }

            return closest;
        }

        private void ShowInteractionText()
        {
            if (UIManager.Instance == null || m_CurrentInteractable == null)
                return;

            UIManager.Instance.ShowInteractionText(
                m_CurrentInteractable.GetInteractText());
        }

        private void HideInteractionText()
        {
            if (UIManager.Instance == null)
                return;

            UIManager.Instance.HideInteractionText();
        }

        #endregion
    }
}