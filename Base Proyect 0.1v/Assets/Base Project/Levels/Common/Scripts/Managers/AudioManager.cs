using Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        #region VAR

        public List<AudioGroup> audioGroups;

        [Header("Debug")]
        [SerializeField]
        private List<AudioFile> pausedAudiosFiles = new List<AudioFile>();

        private bool isLowered = false;
        private bool fadeOut = false;
        private bool fadeIn = false;

        private string fadeInUsedString;
        private string fadeOutUsedString;
        #endregion

        #region METHODS

        private void Awake()
        {
            if (AudioManager.Instance != this)
                Destroy(gameObject);

            for (int j = 0; j < audioGroups.Count; j++)
            {
                //Initialize all audio files
                for (int i = 0; i < audioGroups[j].audioFiles.Count; i++)
                {
                    audioGroups[j].audioFiles[i].source = gameObject.AddComponent<AudioSource>();
                    audioGroups[j].audioFiles[i].source.clip = audioGroups[j].audioFiles[i].audioClip[i];
                    audioGroups[j].audioFiles[i].source.volume = audioGroups[j].audioFiles[i].volume;
                    audioGroups[j].audioFiles[i].source.loop = audioGroups[j].audioFiles[i].isLooping;

                    if (audioGroups[j].audioFiles[i].playOnAwake)
                    {
                        audioGroups[j].audioFiles[i].source.Play();
                    }
                }
            }
        }

        #region Pause      

        /// <summary>
        /// Pause all audio sources, exept noPause name
        /// </summary>
        public void PauseAll(string noPause = "")
        {
            for (int j = 0; j < audioGroups.Count; j++)
            {
                for (int i = 0; i < audioGroups[j].audioFiles.Count; i++)
                {
                    if (audioGroups[j].audioFiles[i].audioName == noPause) continue;

                    if (audioGroups[j].audioFiles[i].source.isPlaying)
                    {
                        audioGroups[j].audioFiles[i].source.Pause();
                        pausedAudiosFiles.Add(audioGroups[j].audioFiles[i]);

                    }
                }
            }
        }

        /// <summary>
        /// Pause all audio sources, exept noPause name
        /// </summary>
        public void PauseAllWithFade(string noPause = "", float time = 0)
        {
            for (int j = 0; j < audioGroups.Count; j++)
            {
                for (int i = 0; i < audioGroups[j].audioFiles.Count; i++)
                {
                    if (audioGroups[j].audioFiles[i].audioName == noPause) continue;

                    if (audioGroups[j].audioFiles[i].source.isPlaying)
                    {
                        FadeOutSource(audioGroups[j].audioFiles[i].audioName, time, false);
                        pausedAudiosFiles.Add(audioGroups[j].audioFiles[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Pause an audio source
        /// </summary>
        /// <param name="name"></param>
        public void PauseSource(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.Pause();
        }

        /// <summary>
        /// Pause all source with same type, except is true pause all source except the selected type
        /// </summary>
        /// <param name="type"></param>
        public void PauseByType(AudioType type, bool except)
        {
            for (int j = 0; j < audioGroups.Count; j++)
            {
                for (int i = 0; i < audioGroups[j].audioFiles.Count; i++)
                {
                    AudioFile audioFile = audioGroups[j].audioFiles[i];

                    bool condition = except ? audioFile.type == type : audioFile.type != type;

                    if (condition) continue;

                    if (audioFile.source.isPlaying)
                    {
                        audioFile.source.Pause();
                        pausedAudiosFiles.Add(audioFile);
                    }
                }
            }
        }

        /// <summary>
        /// Pause a total group
        /// </summary>
        /// <param name="groupName"></param>
        public void PauseByGroup(string groupName)
        {
            AudioGroup audioGroup = audioGroups.Find(AudioGroup => AudioGroup.groupName == groupName);

            for (int i = 0; i < audioGroup.audioFiles.Count; i++)
            {
                if (audioGroup.audioFiles[i].source.isPlaying)
                {
                    audioGroup.audioFiles[i].source.Pause();
                    pausedAudiosFiles.Add(audioGroup.audioFiles[i]);
                }
            }
        }

        /// <summary>
        /// Unpause an audio source
        /// </summary>
        /// <param name="name"></param>
        public void UnPauseSource(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.UnPause();
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
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.Stop();
        }

        #endregion

        #region Play

        /// <summary>
        /// Play an audio source
        /// </summary>
        /// <param name="name"></param>
        public void PlaySource(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.Play();
        }

        /// <summary>
        /// Play an audio source
        /// </summary>
        /// <param name="name"></param>
        public void PlaySourceRandom(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.clip = s.audioClip[Random.Range(0, s.audioClip.Count)];

            s.source.Play();
        }

        /// <summary>
        /// Return a random index que no se repite con el anterior
        /// </summary>
        /// <param name="name"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public int PlaySourceRandom(string name, int previous)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return 0;

            int randomIndex = previous;
            do
            {
                randomIndex = Random.Range(0, s.audioClip.Count);
            } while (randomIndex == previous);

            s.source.clip = s.audioClip[randomIndex];

            s.source.Play();

            return randomIndex;
        }

        /// <summary>
        /// Play a audio source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clip"></param>
        public void PlaySource(string name, AudioClip clip)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.audioClip[0] = clip;
            s.source.clip = clip;
            s.source.Play();
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
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.PlayOneShot(clip);
        }

        /// <summary>
        /// PlayOneShot a clip in source
        /// </summary>
        /// <param name="name"></param>
        public void PlayOneShotInSource(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.PlayOneShot(s.audioClip[0]);
        }

        /// <summary>
        /// Play one shot a source in random 
        /// </summary>
        /// <param name="name"></param>
        public void PlayOneShotInSourceRandom(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.PlayOneShot(s.audioClip[Random.Range(0, s.audioClip.Count)]);
        }

        /// <summary>
        /// Return a random index que no se repite con el anterior
        /// </summary>
        /// <param name="name"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public int PlayOneShotInSourceRandom(string name, int previous)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return 0;

            int randomIndex = previous;
            do
            {
                randomIndex = Random.Range(0, s.audioClip.Count);
            } while (randomIndex == previous);

            s.source.PlayOneShot(s.audioClip[randomIndex]);

            return randomIndex;
        }

        /// <summary>
        /// Return true if source is in playing mode
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsSourcePlaying(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return false;

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
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source.volume = vol;
        }

        /// <summary>
        /// Set the volume an auido source
        /// </summary>
        /// <param name="tmpName"></param>
        /// <param name="tmpVol"></param>
        private void ResetVol(string tmpName, float tmpVol)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

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
                AudioFile s = AudioFileExist(name);
                if (s == null) return;

                StartCoroutine(LowerVolumeForTime(name, s.volume, _duration));
                s.source.volume /= 3;

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
            AudioFile s = AudioFileExist(name);
            if (s == null) yield return null;

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

        /// <summary>
        /// Start a audio with fadein
        /// </summary>
        /// <param name="name"></param>
        /// <param name="targetVolume"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public IEnumerator IFadeIn(string name, float targetVolume, float duration)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) yield return null;

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

        #endregion

        #region Utils

        /// <summary>
        /// Return true if audiofile exist
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private AudioFile AudioFileExist(string name)
        {
            AudioFile s = null;
            for (int i = 0; i < audioGroups.Count; i++)
            {
                s = audioGroups[i].audioFiles.Find(AudioFile => AudioFile.audioName == name);
            }

            if (s == null)
            {
                Debug.LogError("Sound name " + name + " not found!");
                return null;
            }

            return s;
        }

        /// <summary>
        /// Return a audio source with given name file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AudioSource GetSource(string name)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return null;

            return s.source;
        }

        /// <summary>
        /// Remplace the source of a audiofile
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        public void AddSourceToFile(string name, AudioSource source)
        {
            AudioFile s = AudioFileExist(name);
            if (s == null) return;

            s.source = source;
            s.source.clip = s.audioClip[0];
            s.source.volume = s.volume;
            s.source.loop = s.isLooping;
        }

        public Vector2 GetAudioFile(string name)
        {
            Vector2 index = Vector2.zero;

            for (int j = 0; j < audioGroups.Count; j++)
            {
                for (int i = 0; i < audioGroups[j].audioFiles.Count; i++)
                {
                    if (audioGroups[j].audioFiles[i].audioName == name)
                        return new Vector2(j, i);
                }
            }

            return index;
        }

        #endregion

        #endregion
    }

    [System.Serializable]
    public class AudioFile
    {
        public string audioName;
        public List<AudioClip> audioClip = new List<AudioClip>(1);
        [Range(0f, 1f)] public float volume = 1f;

        public bool isLooping;
        public bool playOnAwake;

        public AudioType type;

        [HideInInspector]
        public AudioSource source;
    }

    [System.Serializable]
    public class AudioGroup
    {
        public string groupName;
        public List<AudioFile> audioFiles;
    }

    public enum AudioType
    {
        FX,
        MUSIC,
        OTHER
    }
}