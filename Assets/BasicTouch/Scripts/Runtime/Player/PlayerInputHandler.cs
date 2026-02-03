using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private const string k_Horizontal = "Horizontal";
        private const string k_Vertical = "Vertical";

        private float m_horizontalInput;
        private float m_verticalInput;

        public Vector2 MoveInput { get; private set; }

        private void Update()
        {
            UpdateMoveInput();
        }

        private void UpdateMoveInput()
        {
            m_horizontalInput = Input.GetAxisRaw(k_Horizontal);
            m_verticalInput = Input.GetAxisRaw(k_Vertical);

            MoveInput = new Vector2(m_horizontalInput, m_verticalInput);
        }
    }
}