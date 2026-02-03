using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    /// <summary>
    /// Holds the player's inventory data during runtime.
    /// Uses ScriptableObject for easy inspection and reuse.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerInventory", menuName = "BasicTouch/PlayerInventory")]
    public class PlayerInventory : ScriptableObject
    {
        [SerializeField] private List<ItemProperties> m_CurrentItems = new();

        /// <summary>
        /// Gets the list of items currently owned by the player.
        /// </summary>
        public List<ItemProperties> CurrentItems => m_CurrentItems;

        private void OnEnable()
        {
            CurrentItems.Clear();
        }
    }
}