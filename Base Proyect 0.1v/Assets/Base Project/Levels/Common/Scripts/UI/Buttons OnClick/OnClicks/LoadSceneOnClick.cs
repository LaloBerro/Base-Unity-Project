using UnityEngine;
using Managers;

namespace UnityEngine.UI
{
    public class LoadSceneOnClick : ActionOnClick
    {
        public string scene;

        public override void OnClick()
        {
            GameManager.Instance.LoadScene(scene);
        }
    }
}