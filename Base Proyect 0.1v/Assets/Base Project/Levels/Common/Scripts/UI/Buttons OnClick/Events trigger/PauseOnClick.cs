using Managers;

namespace Common.UI
{
    public class PauseOnClick : TriggerEvent
    {
        public bool toPause;

        public override void Callback()
        {
            GameManager.Instance.Pause(toPause);
        }
    }
}