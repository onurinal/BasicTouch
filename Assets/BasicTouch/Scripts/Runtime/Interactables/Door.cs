using BasicTouch.Runtime.Core;
using DG.Tweening;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractableToggle
    {
        [SerializeField] private DoorLockState m_DoorLockState;

        [Header("Door Animation Settings")]
        [SerializeField] private Transform m_RotatePoint;
        [SerializeField] private float m_RotateAngle;
        [SerializeField] private float m_RotateDuration;

        public bool IsOn { get; set; } = false;

        public void Interact()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
            }

            IsOn = !IsOn;

            PlayAnimation();
        }

        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                return IsOn ? null : "Locked - Key Required";
            }

            return IsOn ? "Close the door " : "Open the door ";
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