using System;

namespace BasicTouch.Runtime.Event
{
    public static class EventManager
    {
        public static event Action OnInteract;

        public static void TriggerOnInteract()
        {
            OnInteract?.Invoke();
        }
    }
}