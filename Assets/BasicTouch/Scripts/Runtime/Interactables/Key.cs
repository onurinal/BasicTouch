using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Player;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    /// <summary>
    /// Represents a key item that can be picked up by the player using
    /// an instant interaction.
    /// </summary>
    public class Key : MonoBehaviour, IInteractableInstant
    {
        #region Serialized Fields

        [SerializeField] private ItemProperties m_ItemData;
        [SerializeField] private PlayerInventory m_PlayerInventory;

        #endregion

        #region Private Fields

        private string m_CurrentInteractText;

        #endregion

        #region Methods

        /// <summary>
        /// Instantly interacts with the key and adds it to the player's inventory.
        /// </summary>
        public void Interact()
        {
            if (m_PlayerInventory == null)
            {
                Debug.LogError($"{nameof(Key)}: PlayerInventory reference is missing.", this);
                return;
            }

            if (m_ItemData == null)
            {
                Debug.LogError($"{nameof(Key)}: ItemData is not assigned.", this);
                return;
            }

            if (m_PlayerInventory.CurrentItems == null)
            {
                Debug.LogError($"{nameof(Key)}: PlayerInventory.CurrentItems is null.", this);
                return;
            }

            m_PlayerInventory.CurrentItems.Add(m_ItemData);
            Destroy(gameObject);
        }

        /// <summary>
        /// Returns the interaction text shown to the player.
        /// </summary>
        /// <returns>Localized interaction prompt text.</returns>
        public string GetInteractText()
        {
            if (m_ItemData == null)
            {
                Debug.LogError($"{nameof(Key)}: ItemData is null while generating interact text.", this);

                return "Pick up item";
            }

            m_CurrentInteractText = $"Pick up the {m_ItemData.name}";
            return m_CurrentInteractText;
        }

        /// <summary>
        /// Gets the transform of this interactable object.
        /// </summary>
        /// <returns>The transform of the key object.</returns>
        public Transform GetTransform()
        {
            return transform;
        }

        #endregion
    }
}