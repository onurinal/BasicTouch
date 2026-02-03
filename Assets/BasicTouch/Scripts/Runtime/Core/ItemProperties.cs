using UnityEngine;

namespace BasicTouch.Runtime.Core
{
    [CreateAssetMenu(fileName = "Item", menuName = "BasicTouch/Item")]
    public class ItemProperties : ScriptableObject
    {
        [SerializeField] private string m_ItemName;
        [SerializeField] private int m_ItemID;

        public string ItemName => m_ItemName;

        public int ItemID => m_ItemID;
    }
}