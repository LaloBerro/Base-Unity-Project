using UnityEngine;

namespace UnityEngine.UI
{
    public abstract class EventTriggerType : MonoBehaviour
    {
        public enum EventUIType { 
        
            OnClickUp,
            OnClickDown,
            OnClickPressed,
            OnEnter,
            OnExit      
        };

        public EventUIType eventType;

        public abstract void Callback();
    }
}