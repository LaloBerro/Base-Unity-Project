using Managers;

namespace UnityEngine.UI
{
    public class QuitApplicationOnClick : ActionOnClick
    {
        public override void OnClick()
        {
            GameManager.Instance.Quit();
        }
    }
}