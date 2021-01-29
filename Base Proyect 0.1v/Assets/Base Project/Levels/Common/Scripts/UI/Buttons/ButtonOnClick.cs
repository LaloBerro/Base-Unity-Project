using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI
{
    public class ButtonOnClick : MonoBehaviour
    {
        private TriggerEvent[] buttonClick;

        private EventTrigger eventTrigger;

        private void Start()
        {
            buttonClick = GetComponents<TriggerEvent>();

            eventTrigger = GetComponent<EventTrigger>();

            for (int i = 0; i < buttonClick.Length; i++)
            {
                buttonClick[i].SubscribeEventTriggerType(eventTrigger);
            }
        }
    }
}