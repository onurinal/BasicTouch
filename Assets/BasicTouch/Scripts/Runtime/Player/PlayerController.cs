using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInputHandler m_playerInputHandler;
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private PlayerProperties m_playerProperties;

        private void Awake()
        {
            if (m_playerInputHandler == null)
            {
                Debug.LogWarning("PlayerInputHandler is null");
                return;
            }

            if (m_rigidbody == null)
            {
                Debug.LogWarning("Rigidbody is null");
                return;
            }

            if (m_playerProperties == null)
            {
                Debug.LogWarning("PlayerProperties is null");
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction = m_playerInputHandler.MoveInput;
            direction.Normalize();
            Vector2 movement = direction * m_playerProperties.MoveSpeed;
            m_rigidbody.linearVelocity = new Vector3(movement.x, m_rigidbody.linearVelocity.y, movement.y);
        }
    }
}