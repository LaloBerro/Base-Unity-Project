using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Common.UI
{
    public class ButtonAnimation : MonoBehaviour
    {
        [Header("Config")]
        public Sprite normal;
        public Sprite pressed;
        public Sprite enter;
        public Sprite exit;
        
        public Image image;
        private EventTrigger eventTrigger;

        private void Start()
        {
            eventTrigger = GetComponent<EventTrigger>();

            SubscribeEventTypes();
        }

        private void SubscribeEventTypes()
        {
            AddTriggerEvent(EventTriggerType.PointerClick, (eventData) => { Pressed(); });
            AddTriggerEvent(EventTriggerType.PointerEnter, (eventData) => { Enter(); });
            AddTriggerEvent(EventTriggerType.PointerExit, (eventData) => { Exit(); });
        }

        private void AddTriggerEvent(EventTriggerType eventTriggerType, UnityEngine.Events.UnityAction<BaseEventData> eventData)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = eventTriggerType
            };

            entry.callback.AddListener(eventData);
            eventTrigger.triggers.Add(entry);
        }

        private void Normal()
        {
            if (normal == null) return;

            image.sprite = normal;
        }

        private void Pressed()
        {
            if (pressed == null) return;            

            image.sprite = pressed;
        }

        private void Enter()
        {
            if (enter == null) return;

            image.sprite = enter;
        }

        private void Exit()
        {
            if (exit == null) return;

            image.sprite = exit;
        }
    }
}