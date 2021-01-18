using Managers;

namespace Common.UI
{
    public class QuitApplicationOnClick : TriggerEvent
    {
        public override void Callback()
        {
            GameManager.Instance.Quit();
        }
    }
}