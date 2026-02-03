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

        public bool IsOn { get; set; }

        public void Interact()
        {
            IsOn = !IsOn;

            var angle = IsOn ? m_RotateAngle : 0;
            m_RotatePoint.DORotate(new Vector3(0, angle, 0), m_RotateDuration);
        }

        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                return IsOn ? null : "Locked - Key Required";
            }

            return IsOn ? "Press E to Open " : "Press E to Close ";
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}