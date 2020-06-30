namespace UnityEngine.UI
{
    public class ReduceSize_EventTrigger : EventTriggerType
    {
        public float reduceAmount = 1.0f;

        private Vector3 startSize;

        private void Awake()
        {
            startSize = transform.localScale;
        }

        public override void Callback()
        {
            transform.localScale -= startSize * reduceAmount;
        }
    }
}