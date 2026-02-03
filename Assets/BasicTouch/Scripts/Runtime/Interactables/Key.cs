using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Player;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    public class Key : MonoBehaviour, IInteractableInstant
    {
        [SerializeField] private ItemProperties m_ItemData;
        [SerializeField] private PlayerInventory m_PlayerInventory;

        private string m_currentInteractText;

        public void Interact()
        {
            m_PlayerInventory.CurrentItems.Add(m_ItemData);
            Destroy(gameObject);
        }

        public string GetInteractText()
        {
            m_currentInteractText = $"Pick up the {m_ItemData.name}";
            return m_currentInteractText;
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}