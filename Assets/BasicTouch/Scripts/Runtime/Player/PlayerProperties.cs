using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Manages player data
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerProperties", menuName = "BasicTouch/PlayerProperties")]
    public class PlayerProperties : ScriptableObject
    {
        [SerializeField] private float m_MoveSpeed = 8;

        /// <summary>
        /// Player movement speed
        /// </summary>
        public float MoveSpeed => m_MoveSpeed;
    }
}