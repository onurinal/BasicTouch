using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Holds the player's inventory data during runtime.
    /// Uses ScriptableObject for easy inspection and reuse.
    /// </summary>
    [CreateAssetMenu(
        fileName = "PlayerInventory",
        menuName = "BasicTouch/Player/Inventory")]
    public class PlayerInventory : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField]
        private List<ItemProperties> m_CurrentItems = new();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of items currently owned by the player.
        /// </summary>
        public List<ItemProperties> CurrentItems => m_CurrentItems;

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            if (m_CurrentItems == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerInventory)}: Current items list is null. Initializing a new list.",
                    this);

                m_CurrentItems = new List<ItemProperties>();
                return;
            }

            m_CurrentItems.Clear();
        }

        #endregion
    }
}