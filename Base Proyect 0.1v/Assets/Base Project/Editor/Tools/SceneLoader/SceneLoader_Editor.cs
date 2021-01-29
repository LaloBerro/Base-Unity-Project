using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace EditorTool
{
    public class SceneLoader_Editor : EditorWindow
    {
        List<SceneAsset> m_SceneAssets = new List<SceneAsset>();

        private Vector2 scrollPosition;
        private bool multiScene;

        // Add menu item named "Example Window" to the Window menu
        [MenuItem("Tools/Scene Loader")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(SceneLoader_Editor), false, "Scene Loader");
        }

        void OnGUI()
        {
            multiScene = EditorGUILayout.Toggle("Multi Scene", multiScene);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(200), GUILayout.MinHeight(1), GUILayout.MaxHeight(1000), GUILayout.ExpandHeight(true));

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {

                GUILayout.Space(10);
                if (GUILayout.Button(GetSceneName(EditorBuildSettings.scenes[i].path)))
                {
                    if (multiScene)
                        EditorSceneManager.OpenScene(EditorBuildSettings.scenes[i].path, OpenSceneMode.Additive);
                    else
                    {
                        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                        EditorSceneManager.OpenScene(EditorBuildSettings.scenes[i].path);
                    }
                }
            }

            GUILayout.EndScrollView();
        }

        private string GetSceneName(string _path)
        {
            char[] path = _path.ToCharArray();
            string sceneName = "";

            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '/')
                    break;
                sceneName += path[i];
            }

            path = sceneName.ToCharArray();
            sceneName = "";

            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '.')
                    break;
                sceneName += path[i];
            }

            return sceneName;
        }    
    }
}