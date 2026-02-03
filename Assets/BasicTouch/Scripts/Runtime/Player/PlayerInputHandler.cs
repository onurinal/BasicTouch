using BasicTouch.Runtime.Event;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Manages player inputs and triggers input events
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private KeyCode m_InteractButton;

        private const string k_Horizontal = "Horizontal";
        private const string k_Vertical = "Vertical";


        private float m_HorizontalInput;
        private float m_VerticalInput;

        #endregion

        #region Properties

        /// <summary>
        /// Movement Input Vector.
        /// </summary>
        public Vector2 MoveInput { get; private set; }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_InteractButton == KeyCode.None)
            {
                Debug.LogWarning($"{nameof(m_InteractButton)} is set to None on {gameObject.name}. " +
                                 "Player will not be able to interact!");
            }
        }

        private void Update()
        {
            UpdateMoveInput();
            UpdateInteractInput();
        }

        #endregion

        #region Methods

        private void UpdateMoveInput()
        {
            m_HorizontalInput = Input.GetAxisRaw(k_Horizontal);
            m_VerticalInput = Input.GetAxisRaw(k_Vertical);

            MoveInput = new Vector2(m_HorizontalInput, m_VerticalInput);
        }

        private void UpdateInteractInput()
        {
            if (Input.GetKeyDown(m_InteractButton))
            {
                EventManager.TriggerOnInteract();
            }
        }

        #endregion
    }
}