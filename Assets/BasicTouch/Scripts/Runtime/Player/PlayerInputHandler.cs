using BasicTouch.Runtime.Manager;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode m_InteractButton;

        private const string k_Horizontal = "Horizontal";
        private const string k_Vertical = "Vertical";

        private float m_horizontalInput;
        private float m_verticalInput;

        public Vector2 MoveInput { get; private set; }

        private void Update()
        {
            UpdateMoveInput();
            UpdateInteractInput();
        }

        private void UpdateMoveInput()
        {
            m_horizontalInput = Input.GetAxisRaw(k_Horizontal);
            m_verticalInput = Input.GetAxisRaw(k_Vertical);

            MoveInput = new Vector2(m_horizontalInput, m_verticalInput);
        }

        private void UpdateInteractInput()
        {
            if (Input.GetKeyDown(m_InteractButton))
            {
                EventManager.TriggerOnInteract();
            }
        }
    }
}