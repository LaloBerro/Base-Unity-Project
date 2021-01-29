using UnityEngine;

namespace Common.UI
{
    public class SetActiveStateOnClick : TriggerEvent
    {
        public GameObject _gameObject;
        public bool activeState;

        public override void Callback()
        {
            _gameObject.SetActive(activeState);   
        }
    }
}