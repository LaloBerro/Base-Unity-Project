using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Patterns;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Debug")]
        public bool pause;
        public string[] nextScenes;
        public float progress;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Set pause state 
        /// </summary>
        public void Pause(bool _pause)
        {
            pause = _pause;

            Time.timeScale = pause ? 0 : 1;

            if (pause)
                AudioManager.Instance.PauseAll();
            else
                AudioManager.Instance.UnpauseAll();
        }

        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        /// <summary>
        /// Carga la escena de loading y despues la escena a la que quiero ir
        /// </summary>
        /// <param name="scene"></param>
        public void LoadScene(string[] scenes)
        {
            progress = 0;
            nextScenes = scenes;
            Time.timeScale = 1;

            StartCoroutine(LoadingScene());
        }

        private IEnumerator LoadingScene()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("Loading");

            yield return new WaitUntil(() => async.isDone);

            AsyncOperation[] asyncOperations = new AsyncOperation[nextScenes.Length];

            for (int i = 0; i < nextScenes.Length; i++)
            {
                asyncOperations[i] = SceneManager.LoadSceneAsync(nextScenes[i]);
            }

            while (!async.isDone)
            {
                progress = Mathf.Clamp01(async.progress / .9f);
                yield return null;
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}