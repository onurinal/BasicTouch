using UnityEngine;

namespace BasicTouch.Runtime.Core
{
    public interface IInteractable
    {
        void Interact();
        string GetInteractText();
        Transform GetTransform();
    }
}