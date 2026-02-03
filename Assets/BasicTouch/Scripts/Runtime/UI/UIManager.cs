using TMPro;
using UnityEngine;

namespace BasicTouch.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI m_InteractionText;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void ShowInteractionText(string text)
        {
            m_InteractionText.text = text;
            m_InteractionText.gameObject.SetActive(true);
        }

        public void HideInteractionText()
        {
            m_InteractionText.gameObject.SetActive(false);
        }

        public void UpdateInteractionText(string text)
        {
            m_InteractionText.text = text;
        }
    }
}