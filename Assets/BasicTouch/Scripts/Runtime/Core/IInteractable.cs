using UnityEngine;

namespace BasicTouch.Runtime.Core
{
    /// <summary>
    /// Defines a base contract for all interactable objects.
    /// </summary>
    public interface IInteractable
    {
        #region Public Methods

        /// <summary>
        /// Executes the interaction logic.
        /// </summary>
        void Interact();

        /// <summary>
        /// Gets the interaction text displayed to the player.
        /// </summary>
        /// <returns>Interaction prompt text.</returns>
        string GetInteractText();

        /// <summary>
        /// Gets the transform of the interactable object.
        /// </summary>
        /// <returns>The transform of the interactable.</returns>
        Transform GetTransform();

        #endregion
    }
}