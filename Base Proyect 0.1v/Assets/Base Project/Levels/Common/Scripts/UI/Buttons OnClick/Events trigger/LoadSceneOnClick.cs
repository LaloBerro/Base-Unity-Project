using Managers;

namespace Common.UI
{
    public class LoadSceneOnClick : TriggerEvent
    {
        public string scene;

        public override void Callback()
        {
            GameManager.Instance.LoadScene(scene);
        }
    }
}