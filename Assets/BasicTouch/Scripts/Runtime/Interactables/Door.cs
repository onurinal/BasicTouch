using BasicTouch.Runtime.Core;
using DG.Tweening;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorLockState m_DoorLockState;

        [Header("Door Animation Settings")]
        [SerializeField] private Transform m_RotatePoint;
        [SerializeField] private float m_RotateAngle;
        [SerializeField] private float m_RotateDuration;

        private bool m_isOpen;

        public void Interact()
        {
            m_isOpen = !m_isOpen;

            var angle = m_isOpen ? -m_RotateAngle : 0;
            m_RotatePoint.DORotate(new Vector3(0, angle, 0), m_RotateDuration);
        }

        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                return m_isOpen ? null : "Locked - Key Required";
            }

            return m_isOpen ? "Press E to Open " : "Press E to Close ";
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}