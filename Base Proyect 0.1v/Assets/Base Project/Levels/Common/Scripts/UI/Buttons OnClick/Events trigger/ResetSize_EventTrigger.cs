using UnityEngine;

namespace Common.UI
{
    public class ResetSize_EventTrigger : TriggerEvent
    {
        private Vector3 startSize;

        private void Awake()
        {
            startSize = transform.localScale;
        }

        public override void Callback()
        {
            transform.localScale = startSize;
        }
    }
}