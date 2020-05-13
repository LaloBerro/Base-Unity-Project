using UnityEngine;

namespace UnityEngine.UI
{
    public class ButtonOnClick : MonoBehaviour
    {
        private ActionOnClick[] buttonClick;

        private void Start()
        {
            buttonClick = GetComponents<ActionOnClick>();
        }

        public void OnClick()
        {
            for (int i = 0; i < buttonClick.Length; i++)
            {
                buttonClick[i].OnClick();
            }
        }
    }
}