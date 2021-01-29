using Levels.Common.Scenes;
using Managers;

namespace Common.UI
{
    public class LoadSceneOnClick : TriggerEvent
    {
        public SceneData scene;

        public override void Callback()
        {
            ScenesManager.Instance.LoadScene(scene);
        }
    }
}