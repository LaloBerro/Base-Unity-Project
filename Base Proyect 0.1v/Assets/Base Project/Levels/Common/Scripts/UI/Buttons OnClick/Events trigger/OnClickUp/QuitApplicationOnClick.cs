using Managers;

namespace UnityEngine.UI
{
    public class QuitApplicationOnClick : EventTriggerType
    {
        public override void Callback()
        {
            GameManager.Instance.Quit();
        }
    }
}