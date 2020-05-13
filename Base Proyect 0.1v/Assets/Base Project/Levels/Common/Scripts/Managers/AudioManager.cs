using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource musicSource;
        private AudioSource FXsource;

        private List<AudioSource> sources = new List<AudioSource>();

        private void Awake()
        {
            FXsource = GetComponent<AudioSource>();
        }

        public void Pause()
        {
            List<GameObject> sourcesGO = new List<GameObject>(GameObject.FindGameObjectsWithTag("PauseableSource"));

            for (int i = 0; i < sourcesGO.Count; i++)
            {
                if (sourcesGO[i].GetComponent<AudioSource>().isPlaying)
                    sources.Add(sourcesGO[i].GetComponent<AudioSource>());
            }

            for (int i = 0; i < sources.Count; i++)
            {
                sources[i].Pause();
            }
        }

        public void Reanude()
        {
            for (int i = 0; i < sources.Count; i++)
            {
                sources[i].Play();
            }
        }

        public void PlayOneShot(AudioClip _clip)
        {
            FXsource.PlayOneShot(_clip);
        }

        public void Play(AudioClip _clip)
        {
            FXsource.clip = _clip;
            FXsource.Play();
        }
    }
}