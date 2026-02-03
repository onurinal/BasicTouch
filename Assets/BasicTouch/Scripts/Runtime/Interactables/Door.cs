using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Player;
using DG.Tweening;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractableToggle
    {
        [SerializeField] private DoorLockState m_DoorLockState;
        [SerializeField] private ItemProperties m_RequiredKey;
        [SerializeField] private PlayerInventory m_PlayerInventory;

        [Header("Door Animation Settings")]
        [SerializeField] private Transform m_RotatePoint;
        [SerializeField] private float m_RotateAngle;
        [SerializeField] private float m_RotateDuration;

        private string m_currentInteractText;
        public bool IsOn { get; set; } = false;

        public void Interact()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                bool hasKey = m_PlayerInventory.CurrentItems.Contains(m_RequiredKey);

                if (hasKey && !IsOn)
                {
                    IsOn = true;
                    PlayAnimation();
                    m_PlayerInventory.CurrentItems.Remove(m_RequiredKey);
                }
                else if (!hasKey && IsOn)
                {
                    m_currentInteractText = "";
                }
                else
                {
                    m_currentInteractText = $"You need {m_RequiredKey.ItemName} to open the door!";
                }

                return;
            }

            IsOn = !IsOn;
            PlayAnimation();
        }

        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                bool hasKey = m_PlayerInventory.CurrentItems.Contains(m_RequiredKey);

                if (!hasKey && !IsOn)
                {
                    m_currentInteractText = $"Locked - Required {m_RequiredKey.ItemName}";
                }
                else if (hasKey && !IsOn)
                {
                    m_currentInteractText = "You can open the door with key!";
                }
                else
                {
                    return null;
                }
            }
            else
            {
                m_currentInteractText = IsOn ? "Close the door " : "Open the door ";
            }

            return m_currentInteractText;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        private void PlayAnimation()
        {
            var angle = IsOn ? m_RotateAngle : 0;
            m_RotatePoint.DORotate(new Vector3(0, angle, 0), m_RotateDuration);
        }
    }
}