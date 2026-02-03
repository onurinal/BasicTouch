namespace BasicTouch.Runtime.Core
{
    public interface IInteractableHold : IInteractable
    {
        float HoldTime { get; set; }
    }
}