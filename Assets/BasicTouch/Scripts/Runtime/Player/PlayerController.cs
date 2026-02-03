using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerProperties m_PlayerProperties;
        [SerializeField] private PlayerInputHandler m_playerInputHandler;
        [SerializeField] private Rigidbody m_rigidbody;

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
            Vector2 inputDirection = m_playerInputHandler.MoveInput;

            Vector3 cameraForward = m_mainCamera.transform.forward;
            Vector3 cameraRight = m_mainCamera.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            m_movementDirection = (inputDirection.y * cameraForward + inputDirection.x * cameraRight).normalized;
        }

        private void Move()
        {
            if (m_rigidbody == null)
            {
                Debug.LogWarning("Rigidbody is null");
                return;
            }

            Vector3 movement = m_movementDirection * m_PlayerProperties.MoveSpeed;
            m_rigidbody.linearVelocity = new Vector3(movement.x, m_rigidbody.linearVelocity.y, movement.z);
        }
    }
}