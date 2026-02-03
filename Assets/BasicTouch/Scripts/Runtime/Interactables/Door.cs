using BasicTouch.Runtime.Core;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorLockState m_DoorLockState;

        [SerializeField] private Transform m_RotatePoint;
        [SerializeField] private float m_RotateAngle;

        private bool m_isOpen;

        public void Interact()
        {
            m_isOpen = !m_isOpen;

            m_RotatePoint.transform.rotation = m_isOpen ? Quaternion.Euler(0, m_RotateAngle, 0) : Quaternion.Euler(0, 0, 0);
        }

        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                return m_isOpen ? null : "Locked - Key Required";
            }

            return m_isOpen ? "Press E to Open " : "Press E to Close ";
        }
    }
}