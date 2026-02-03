using UnityEngine;

namespace BasicTouch.Runtime.Core
{
    /// <summary>
    /// Contains items data
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "BasicTouch/Item")]
    public class ItemProperties : ScriptableObject
    {
        #region Fields

        [SerializeField] private string m_ItemName;
        [SerializeField] private int m_ItemID;

        #endregion

        #region Properties

        /// <summary>
        /// Item'ın görünen adı.
        /// </summary>
        public string ItemName => m_ItemName;

        /// <summary>
        /// Item'ın ID'si.
        /// </summary>
        public int ItemID => m_ItemID;

        #endregion
    }
}