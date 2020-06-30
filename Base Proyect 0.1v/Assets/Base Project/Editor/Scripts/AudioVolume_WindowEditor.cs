using Managers;
using UnityEditor;

namespace EditorTool
{
    public class AudioVolume_WindowEditor : EditorWindow
    {
        AudioManager audiomanager = null;

        [MenuItem("Tools/Audio Volumes")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(AudioVolume_WindowEditor), false, "Audio Volumes");
        }

        void OnGUI()
        {
            if (audiomanager == null) audiomanager = FindObjectOfType<AudioManager>();

            if (audiomanager == null) return;

            EditorGUILayout.LabelField("Souns In scene", EditorStyles.boldLabel);

            EditorGUILayout.BeginVertical("box");
            
            for (int i = 0; i < audiomanager.audioFiles.Length; i++)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.BeginVertical("box");

                var serializedObject = new SerializedObject(audiomanager);
                var property = serializedObject.FindProperty("audioFiles");
                property.GetArrayElementAtIndex(i).FindPropertyRelative("volume").floatValue = EditorGUILayout.Slider(audiomanager.audioFiles[i].audioName, audiomanager.audioFiles[i].volume, 0f, 1f);
                serializedObject.ApplyModifiedProperties();

                EditorGUILayout.EndVertical();
                EditorGUI.EndChangeCheck();
            }

            EditorGUILayout.EndVertical();
        }
    }
}