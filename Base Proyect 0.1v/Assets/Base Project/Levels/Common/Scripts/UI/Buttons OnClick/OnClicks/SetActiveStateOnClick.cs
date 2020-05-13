
namespace UnityEngine.UI
{
    public class SetActiveStateOnClick : ActionOnClick
    {
        public GameObject _gameObject;
        public bool activeState;

        public override void OnClick()
        {
            _gameObject.SetActive(activeState);   
        }
    }
}