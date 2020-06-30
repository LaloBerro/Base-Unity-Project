using Managers;
using UnityEngine;

namespace Utils
{
    public class AudioController : MonoBehaviour
    {
        public string audioName;
        public bool stopAudioOnDisable = true;
        public bool playAudioOnEnable = true;

        private void OnDisable()
        {
            if (stopAudioOnDisable)
                AudioManager.Instance.StopSource(audioName);
        }

        private void OnEnable()
        {
            if (!playAudioOnEnable) return;
            if (AudioManager.Instance.IsSourcePlaying(audioName)) return;

            AudioManager.Instance.PlaySource(audioName);
        }
    }
}