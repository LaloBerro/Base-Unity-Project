using Managers;

namespace UnityEngine.UI
{
    public class PauseOnClick : ActionOnClick
    {
        public bool toPause;

        public override void OnClick()
        {
            GameManager.Instance.Pause(toPause);
        }
    }
}