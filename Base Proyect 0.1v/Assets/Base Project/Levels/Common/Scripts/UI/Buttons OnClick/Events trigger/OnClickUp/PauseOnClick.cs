using Managers;

namespace UnityEngine.UI
{
    public class PauseOnClick : EventTriggerType
    {
        public bool toPause;

        public override void Callback()
        {
            GameManager.Instance.Pause(toPause);
        }
    }
}