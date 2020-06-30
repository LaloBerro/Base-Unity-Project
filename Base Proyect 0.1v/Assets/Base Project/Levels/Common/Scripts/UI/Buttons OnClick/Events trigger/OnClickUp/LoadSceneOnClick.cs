using UnityEngine;
using Managers;

namespace UnityEngine.UI
{
    public class LoadSceneOnClick : EventTriggerType
    {
        public string scene;

        public override void Callback()
        {
            GameManager.Instance.LoadScene(scene);
        }
    }
}