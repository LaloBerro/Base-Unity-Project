using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI
{
    public abstract class TriggerEvent : MonoBehaviour
    {
        public EventTriggerType eventType;

        public abstract void Callback();

        /// <summary>
        /// Subcribe a new event 
        /// </summary>
        /// <param name="eventTrigger"></param>
        public void SubscribeEventTriggerType(EventTrigger eventTrigger)
        {
            AddTriggerEvent(eventTrigger, eventType, (eventData) => { Callback(); });
        }

        private void AddTriggerEvent(EventTrigger eventTrigger, EventTriggerType eventTriggerType, UnityEngine.Events.UnityAction<BaseEventData> eventData)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = eventTriggerType
            };

            entry.callback.AddListener(eventData);
            eventTrigger.triggers.Add(entry);
        }
    }
}