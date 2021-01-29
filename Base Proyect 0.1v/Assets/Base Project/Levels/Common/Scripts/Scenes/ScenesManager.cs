using Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.Common.Scenes
{
    public class ScenesManager : Singleton<ScenesManager>
    {
        [Header("Debug")]

        [SerializeField] private float _loadProgress = 0;

        [SerializeField] private SceneData _currentLoaderData;

        [SerializeField] private List<SceneData> openScenes = new List<SceneData>();

        [SerializeField] private const string _loadingSceneName = "Loading";

        private void Awake()
        {
            PassTroughScenes();
        }

        /// <summary>
        /// Set and run the SceneLoaderData
        /// </summary>
        /// <param name="loaderData"></param>
        public void LoadScene(SceneData loaderData)
        {
            RemoveOpenScenes();

            _currentLoaderData = loaderData;

            StartCoroutine(LoadScenes());
        }

        public void RemoveOpenScenes()
        {
            for (int i = 0; i < openScenes.Count; i++)
            {
                if (openScenes[i].keepOpen) continue;

                SceneManager.UnloadSceneAsync(openScenes[i].sceneName);

                openScenes.RemoveAt(i);

                i--;
            }
        }

        /// <summary>
        /// Load all scenes asynchronous
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadScenes() 
        {
            //Load Loading screen
            if (_currentLoaderData.useLoadingSreen)
                yield return StartCoroutine(LoadingScreen());

            SceneData[] scenesToLoad = _currentLoaderData.GetScenes();

            int totalScenesToLoad = scenesToLoad.Length;

            // Load async scenes
            AsyncOperation[] loadSceneAsyncOperations = new AsyncOperation[totalScenesToLoad];

            for (int i = 0; i < totalScenesToLoad; i++)
            {
                SceneData sceneToLoad = scenesToLoad[i];

                loadSceneAsyncOperations[i] = SceneManager.LoadSceneAsync(sceneToLoad.sceneName, LoadSceneMode.Additive);

                openScenes.Add(sceneToLoad);

                yield return null;
            }

            //Save the load progress 
            yield return StartCoroutine(SetLoadProgress(loadSceneAsyncOperations));

            OnFinishLoad();
        }

        /// <summary>
        /// Load a loading screen scene asynchronous
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadingScreen()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(_loadingSceneName);

            yield return new WaitUntil(() => async.isDone);
        }

        /// <summary>
        /// Set the progress of the load scene process
        /// </summary>
        /// <param name="loadSceneAsyncOperations"></param>
        /// <returns></returns>
        private IEnumerator SetLoadProgress(AsyncOperation[] loadSceneAsyncOperations)
        {
            int totalScenesToLoad = loadSceneAsyncOperations.Length;
            float totalProgress = 0;

            for (int i = 0; i < totalScenesToLoad; i++)
            {
                while (!loadSceneAsyncOperations[i].isDone)
                {
                    totalProgress += loadSceneAsyncOperations[i].progress;
                    _loadProgress = totalProgress / totalScenesToLoad;
                    yield return null;
                }
            }
        }

        private void OnFinishLoad()
        {
            if (_currentLoaderData.useLoadingSreen)
                SceneManager.UnloadSceneAsync(_loadingSceneName);

            Debug.Log("The Load scenes is finished");
        }
    }
}