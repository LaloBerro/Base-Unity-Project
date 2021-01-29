using UnityEngine;

namespace Common.UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        public abstract void OnEnterPanel();
        public abstract void OnExitPanel();
    }
}