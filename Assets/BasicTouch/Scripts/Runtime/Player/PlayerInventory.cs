using System.Collections.Generic;
using BasicTouch.Runtime.Core;
using UnityEngine;

namespace BasicTouch.Runtime.Player
{
    [CreateAssetMenu(fileName = "PlayerInventory", menuName = "BasicTouch/PlayerInventory")]
    public class PlayerInventory : ScriptableObject
    {
        [SerializeField] private List<ItemProperties> m_CurrentItems = new();

        public List<ItemProperties> CurrentItems => m_CurrentItems;

        private void OnEnable()
        {
            CurrentItems.Clear();
        }
    }
}