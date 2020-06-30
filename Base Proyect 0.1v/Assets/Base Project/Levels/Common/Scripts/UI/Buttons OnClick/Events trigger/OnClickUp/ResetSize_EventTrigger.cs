namespace UnityEngine.UI
{
    public class ResetSize_EventTrigger : EventTriggerType
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