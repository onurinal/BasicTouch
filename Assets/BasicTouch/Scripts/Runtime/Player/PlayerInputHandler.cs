using System;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInputActions m_inputActions;

        public Vector2 MoveInput { get; private set; }

        public event Action OnInteract;

        private void OnEnable()
        {
            if (m_inputActions == null)
            {
                m_inputActions = new PlayerInputActions();
            }

            m_inputActions.Enable();
            m_inputActions.Player.Interact.performed += ctx => OnInteract?.Invoke();
        }

        private void OnDisable()
        {
            m_inputActions?.Disable();
        }

        private void Update()
        {
            UpdateMoveInput();
        }

        private void UpdateMoveInput()
        {
            MoveInput = m_inputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}