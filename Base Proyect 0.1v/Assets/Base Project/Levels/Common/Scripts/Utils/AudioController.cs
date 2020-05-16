using UnityEngine;

namespace Utils
{
    public class AudioController : MonoBehaviour
    {
        public string audioName;
        public bool stopAudioOnDisable;

        private void OnDisable()
        {
            if(stopAudioOnDisable)
                AudioManager.Instance.StopSource(audioName);
        }
    }
}