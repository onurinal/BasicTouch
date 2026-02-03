namespace BasicTouch.Runtime.Core
{
    public interface IInteractableToggle : IInteractable
    {
        bool IsOn { get; set; }
    }
}