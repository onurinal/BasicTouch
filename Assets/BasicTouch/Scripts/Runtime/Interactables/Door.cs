using BasicTouch.Runtime.Core;
using BasicTouch.Runtime.Player;
using DG.Tweening;
using UnityEngine;

namespace BasicTouch.Runtime.Interactables
{
    /// <summary>
    /// Açılıp kapanabilen ve kilitlenebilen kapı sistemi.
    /// Toggle interaction ile çalışır ve anahtar gerektiren kilitli mod destekler.
    /// </summary>
    public class Door : MonoBehaviour, IInteractableToggle
    {
        #region Fields

        // Serialized private instance fields
        [Header("Door Settings")]
        [SerializeField] private DoorLockState m_DoorLockState;
        [SerializeField] private ItemProperties m_RequiredKey;
        [SerializeField] private PlayerInventory m_PlayerInventory;

        [Header("Door Animation Settings")]
        [SerializeField] private Transform m_RotatePoint;
        [SerializeField] private float m_RotateAngle = 90f;
        [SerializeField] private float m_RotateDuration = 2f;

        // Non-serialized private instance fields
        private string m_CurrentInteractText;

        #endregion

        #region Properties

        /// <summary>
        /// Kapının açık olup olmadığını belirtir.
        /// </summary>
        public bool IsOn { get; set; }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            ValidateReferences();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gerekli referansları doğrular.
        /// </summary>
        private void ValidateReferences()
        {
            if (m_RotatePoint == null)
            {
                Debug.LogError($"[Door] RotatePoint is null on {gameObject.name}. Please assign it in the Inspector.");
            }

            if (m_DoorLockState == DoorLockState.Locked)
            {
                if (m_RequiredKey == null)
                {
                    Debug.LogError($"[Door] RequiredKey is null on {gameObject.name}, but door is set to Locked state.");
                }

                if (m_PlayerInventory == null)
                {
                    Debug.LogError($"[Door] PlayerInventory is null on {gameObject.name}, but door is set to Locked state.");
                }
            }
        }

        /// <summary>
        /// Kapının açılması/kapanması için animasyon oynatır.
        /// </summary>
        private void PlayAnimation()
        {
            if (m_RotatePoint == null)
            {
                Debug.LogError($"[Door] Cannot play animation. RotatePoint is null on {gameObject.name}.");
                return;
            }

            float targetAngle = IsOn ? m_RotateAngle : 0f;
            m_RotatePoint.DORotate(new Vector3(0f, targetAngle, 0f), m_RotateDuration);
        }

        /// <summary>
        /// Oyuncunun anahtara sahip olup olmadığını kontrol eder.
        /// </summary>
        /// <returns>Anahtar varsa true, yoksa false.</returns>
        private bool HasRequiredKey()
        {
            if (m_PlayerInventory == null)
            {
                Debug.LogError($"[Door] PlayerInventory is null on {gameObject.name}. Cannot check for key.");
                return false;
            }

            if (m_RequiredKey == null)
            {
                Debug.LogError($"[Door] RequiredKey is null on {gameObject.name}. Cannot check for key.");
                return false;
            }

            return m_PlayerInventory.CurrentItems.Contains(m_RequiredKey);
        }

        /// <summary>
        /// Envanterdeki anahtarı kullanır (siler).
        /// </summary>
        private void ConsumeKey()
        {
            if (m_PlayerInventory == null || m_RequiredKey == null)
            {
                Debug.LogError($"[Door] Cannot consume key. PlayerInventory or RequiredKey is null on {gameObject.name}.");
                return;
            }

            if (m_PlayerInventory.CurrentItems.Contains(m_RequiredKey))
            {
                m_PlayerInventory.CurrentItems.Remove(m_RequiredKey);
            }
            else
            {
                Debug.LogWarning($"[Door] Attempted to consume key that player doesn't have on {gameObject.name}.");
            }
        }

        #endregion

        #region Interface Implementations

        /// <summary>
        /// Kapı ile etkileşime geçer. Kilitli kapılar için anahtar kontrolü yapar.
        /// </summary>
        public void Interact()
        {
            // Kilitli kapı mantığı
            if (m_DoorLockState == DoorLockState.Locked)
            {
                bool hasKey = HasRequiredKey();

                // Kapı kapalı ve anahtar var - aç ve anahtarı kullan
                if (hasKey && !IsOn)
                {
                    IsOn = true;
                    PlayAnimation();
                    ConsumeKey();
                    m_CurrentInteractText = string.Empty;
                    return;
                }

                if (!hasKey && IsOn)
                {
                    return;
                }

                // Anahtar yok ve kapı kapalı - etkileşim yapma
                if (!hasKey && !IsOn)
                {
                    m_CurrentInteractText = m_RequiredKey != null
                        ? $"You need {m_RequiredKey.ItemName} to open the door!"
                        : "This door is locked!";
                    return;
                }
            }

            // Normal toggle davranışı (kilitsiz kapılar veya açık kilitli kapılar için)
            IsOn = !IsOn;
            PlayAnimation();
        }

        /// <summary>
        /// Etkileşim prompt metnini döndürür.
        /// </summary>
        public string GetInteractText()
        {
            if (m_DoorLockState == DoorLockState.Locked)
            {
                bool hasKey = HasRequiredKey();

                if (!hasKey && !IsOn)
                {
                    m_CurrentInteractText = m_RequiredKey != null
                        ? $"Locked - Required {m_RequiredKey.ItemName}"
                        : "Locked";
                    return m_CurrentInteractText;
                }

                if (hasKey && !IsOn)
                {
                    m_CurrentInteractText = "Press to unlock with key";
                    return m_CurrentInteractText;
                }
            }
            else
            {
                // Kilitsiz kapı için metin
                m_CurrentInteractText = IsOn ? "Press to close door" : "Press to open door";
            }

            return m_CurrentInteractText;
        }

        /// <summary>
        /// Bu objenin Transform component'ini döndürür.
        /// </summary>
        /// <returns>Transform component.</returns>
        public Transform GetTransform()
        {
            return transform;
        }

        #endregion
    }
}