
namespace UnityEngine.UI
{
    public class SetActiveStateOnClick : EventTriggerType
    {
        public GameObject _gameObject;
        public bool activeState;

        public override void Callback()
        {
            _gameObject.SetActive(activeState);   
        }
    }
}