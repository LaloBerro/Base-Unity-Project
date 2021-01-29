using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.Common.Scenes
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "Scenes/SceneData")]
    public class SceneData : ScriptableObject
    {
        [Header("Config")]
        public string sceneName;
        public LoadSceneMode mode;
        public bool useLoadingSreen = true;

        [Header("Scenes to load")]
        public SceneData[] scenesData;

        public bool keepOpen;

        public SceneData[] GetScenes()
        {
            Debug.Log("Scenedata " + sceneName);
            SceneData[] scenes = new SceneData[scenesData.Length + 1];

            scenes[scenesData.Length] = this;

            for (int i = 0; i < scenesData.Length; i++)
            {
                scenes[i] = scenesData[i];
            }

            return scenes;
        }
    }
}