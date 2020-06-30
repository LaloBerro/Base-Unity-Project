using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        #region VAR

        public AudioFile[] audioFiles;

        [Header("Debug")]
        [SerializeField]
        private List<AudioFile> pausedAudiosFiles = new List<AudioFile>();

        private bool isLowered = false;
        private bool fadeOut = false;
        private bool fadeIn = false;

        private string fadeInUsedString;
        private string fadeOutUsedString;
        #endregion

        void Awake()
        {
            //Initialize all audio files
            for (int i = 0; i < audioFiles.Length; i++)
            {
                audioFiles[i].source = gameObject.AddComponent<AudioSource>();
                audioFiles[i].source.clip = audioFiles[i].audioClip;
                audioFiles[i].source.volume = audioFiles[i].volume;
                audioFiles[i].source.loop = audioFiles[i].isLooping;

                if (audioFiles[i].playOnAwake)
                {
                    audioFiles[i].source.Play();
                }
            }
        }

        #region METHODS

        #region Pause      

        /// <summary>
        /// Pause all audio sources, exept noPause name
        /// </summary>
        public void PauseAll(string noPause = "")
        {
            for (int i = 0; i < audioFiles.Length; i++)
            {
                if (audioFiles[i].audioName == noPause) continue;

                if (audioFiles[i].source.isPlaying)
                {
                    audioFiles[i].source.Pause();
                    pausedAudiosFiles.Add(audioFiles[i]);
                }
            }
        }

        /// <summary>
        /// Pause all audio sources, exept noPause name
        /// </summary>
        public void PauseAllWithFade(string noPause = "", float time = 0)
        {
            for (int i = 0; i < audioFiles.Length; i++)
            {
                if (audioFiles[i].audioName == noPause) continue;

                if (audioFiles[i].source.isPlaying)
                {
                    FadeOutSource(audioFiles[i].audioName, time, false);
                    pausedAudiosFiles.Add(audioFiles[i]);
                }
            }
        }

        /// <summary>
        /// Pause an audio source
        /// </summary>
        /// <param name="name"></param>
        public void PauseSource(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.Pause();
            }
        }

        /// <summary>
        /// Unpause an audio source
        /// </summary>
        /// <param name="name"></param>
        public void UnPauseSource(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);

            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.UnPause();
            }
        }

        /// <summary>
        /// Unpause the paused audios source
        /// </summary>
        public void UnpauseAll()
        {
            for (int i = 0; i < pausedAudiosFiles.Count; i++)
            {
                pausedAudiosFiles[i].source.Play();
            }

            pausedAudiosFiles.Clear();
        }

        /// <summary>
        /// Stop an auido source
        /// </summary>
        /// <param name="name"></param>
        public void StopSource(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.Stop();
            }
        }

        #endregion

        #region Play

        /// <summary>
        /// Play an audio source
        /// </summary>
        /// <param name="name"></param>
        public void PlaySource(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.Play();
            }
        }

        /// <summary>
        /// Play a audio source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clip"></param>
        public void PlaySource(string name, AudioClip clip)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.audioClip = clip;
                s.source.clip = clip;
                s.source.Play();
            }
        }

        /// <summary>
        /// Play in one shot a clip
        /// </summary>
        /// <param name="clip"></param>
        public void PlayOneShot(AudioClip clip)
        {
            PlayOneShotInSource("PlayOneShot", clip);
        }

        /// <summary>
        /// Play in one shot a clip in a given source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clip"></param>
        public void PlayOneShotInSource(string name, AudioClip clip)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.PlayOneShot(clip);
            }
        }

        public bool IsSourcePlaying(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);

            if (s.source == null)
            {
                Debug.LogError("Sound name " + name + " not found!");
                return false;
            }

            return s.source.isPlaying;
        }

        #endregion

        #region Volume

        /// <summary>
        /// Set the volume of a audiosource
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vol"></param>
        public void SetVolume(string name, float vol)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return;
            }
            else
            {
                s.source.volume = vol;
            }
        }

        /// <summary>
        /// Set the volume an auido source
        /// </summary>
        /// <param name="tmpName"></param>
        /// <param name="tmpVol"></param>
        private void ResetVol(string tmpName, float tmpVol)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == tmpName);
            s.source.volume = tmpVol;
            isLowered = false;
        }

        /// <summary>
        /// Reduce the volume of an audio source for a time
        /// </summary>
        /// <param name="name"></param>
        /// <param name="_duration"></param>
        public void LowerVolumeSource(string name, float _duration)
        {
            if (isLowered == false)
            {
                AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
                if (s == null)
                {
                    Debug.LogError("Sound name" + name + "not found!");
                    return;
                }
                else
                {
                    StartCoroutine(LowerVolumeForTime(name, s.volume, _duration));
                    s.source.volume /= 3;
                }
                isLowered = true;
            }
        }

        /// <summary>
        /// Set the volume to 0 for a time
        /// </summary>
        /// <param name="tmpName"></param>
        /// <param name="tmpVol"></param>
        /// <param name="_duration"></param>
        /// <returns></returns>
        private IEnumerator LowerVolumeForTime(string tmpName, float tmpVol, float _duration)
        {
            yield return new WaitForSeconds(_duration);
            ResetVol(tmpName, tmpVol);
        }

        /// <summary>
        /// Stop an audio source with a fade
        /// </summary>
        /// <param name="name"></param>
        /// <param name="duration"></param>
        public void FadeOutSource(string name, float duration, bool stop = true)
        {
            StartCoroutine(IFadeOut(name, duration, stop));
        }

        /// <summary>
        /// Play an audio source with fade
        /// </summary>
        /// <param name="name"></param>
        /// <param name="targetVolume"></param>
        /// <param name="duration"></param>
        public void FadeInSource(string name, float targetVolume, float duration)
        {
            StartCoroutine(IFadeIn(name, targetVolume, duration));
        }

        /// <summary>
        /// Leave a audio source with Fade Out
        /// </summary>
        /// <param name="name"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator IFadeOut(string name, float duration, bool stop = true)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);

            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                yield return null;
            }
            else
            {
                if (fadeOut == false)
                {
                    fadeOut = true;
                    float startVol = s.source.volume;
                    fadeOutUsedString = name;
                    while (s.source.volume > 0)
                    {
                        s.source.volume -= startVol * Time.deltaTime / duration;
                        yield return null;
                    }

                    if (stop)
                        s.source.Stop();
                    else
                        s.source.Pause();

                    yield return new WaitForSeconds(duration);
                    fadeOut = false;
                }
                else
                {
                    Debug.Log("Could not handle two fade outs at once : " + name + " , " + fadeOutUsedString + "! Stopped the music " + name);
                    StopSource(name);
                }
            }
        }

        /// <summary>
        /// Start a audio with fadein
        /// </summary>
        /// <param name="name"></param>
        /// <param name="targetVolume"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public IEnumerator IFadeIn(string name, float targetVolume, float duration)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                yield return null;
            }
            else
            {
                if (fadeIn == false)
                {
                    fadeIn = true;
                    fadeInUsedString = name;
                    s.source.volume = 0f;
                    s.source.Play();
                    while (s.source.volume < targetVolume)
                    {
                        s.source.volume += Time.deltaTime / duration;
                        yield return null;
                    }
                    yield return new WaitForSeconds(duration);
                    fadeIn = false;
                }
                else
                {
                    Debug.Log("Could not handle two fade ins at once: " + name + " , " + fadeInUsedString + "! Played the music " + name);
                    StopSource(fadeInUsedString);
                    PlaySource(name);
                }
            }
        }

        #endregion

        #region Utils

        /// <summary>
        /// Return a audio source with given name file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AudioSource GetSource(string name)
        {
            AudioFile s = Array.Find(audioFiles, AudioFile => AudioFile.audioName == name);
            if (s == null)
            {
                Debug.LogError("Sound name" + name + "not found!");
                return null;
            }
            else
            {
                return s.source;
            }
        }

        #endregion

        #endregion
    }

    [System.Serializable]
    public class AudioFile
    {
        public string audioName;
        public AudioClip audioClip;
        [Range(0f, 1f)]
        public float volume;

        [HideInInspector]
        public AudioSource source;
        public bool isLooping;
        public bool playOnAwake;
    }
}