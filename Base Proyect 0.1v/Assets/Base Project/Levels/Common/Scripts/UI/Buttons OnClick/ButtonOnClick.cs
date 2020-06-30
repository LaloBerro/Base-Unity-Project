namespace UnityEngine.UI
{
    public class ButtonOnClick : MonoBehaviour
    {
        private EventTriggerType[] buttonClick;

        private void Start()
        {
            buttonClick = GetComponents<EventTriggerType>();
        }

        public void OnClickUp()
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                if(buttonClick[i].eventType == EventTriggerType.EventUIType.OnClickUp)
                    buttonClick[i].Callback();
            }
        }

        public void OnClickDown()
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                if (buttonClick[i].eventType == EventTriggerType.EventUIType.OnClickDown)
                    buttonClick[i].Callback();
            }
        }

        public void OnClickPressed() 
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                if (buttonClick[i].eventType == EventTriggerType.EventUIType.OnClickPressed)
                    buttonClick[i].Callback();
            }
        }

        public void OnEnter()
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                if (buttonClick[i].eventType == EventTriggerType.EventUIType.OnEnter)
                    buttonClick[i].Callback();
            }
        }

        public void OnExit()
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                if (buttonClick[i].eventType == EventTriggerType.EventUIType.OnExit)
                    buttonClick[i].Callback();
            }
        }
    }
}