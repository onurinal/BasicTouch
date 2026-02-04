using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Handles player movement and physics-based control.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("References")]
        [SerializeField] private PlayerProperties m_PlayerData;
        [SerializeField] private PlayerInputHandler m_PlayerInputHandler;
        [SerializeField] private Rigidbody m_Rigidbody;

        #endregion

        #region Private Fields

        private Vector3 m_MovementDirection;
        private Camera m_MainCamera;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_PlayerData == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerController)}: PlayerProperties reference is missing.",
                    this);
                enabled = false;
                return;
            }

            if (m_Rigidbody == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerController)}: Rigidbody reference is missing.",
                    this);
                enabled = false;
                return;
            }

            m_MainCamera = Camera.main;
            if (m_MainCamera == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerController)}: Main camera not found.",
                    this);
                enabled = false;
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

        #endregion

        #region Methods

        private void CalculateMoveDirection()
        {
            Vector2 inputDirection = m_PlayerInputHandler.MoveInput;

            Vector3 cameraForward = m_MainCamera.transform.forward;
            Vector3 cameraRight = m_MainCamera.transform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            m_MovementDirection =
                (inputDirection.y * cameraForward +
                 inputDirection.x * cameraRight).normalized;
        }

        private void Move()
        {
            Vector3 movement = m_MovementDirection * m_PlayerData.MoveSpeed;

            m_Rigidbody.linearVelocity = new Vector3(
                movement.x,
                m_Rigidbody.linearVelocity.y,
                movement.z);
        }

        #endregion
    }
}