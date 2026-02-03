using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    [CreateAssetMenu(fileName = "PlayerProperties", menuName = "BasicTouch/PlayerProperties")]
    public class PlayerProperties : ScriptableObject
    {
        [SerializeField] private float m_MoveSpeed = 8;

        public float MoveSpeed => m_MoveSpeed;
    }
}