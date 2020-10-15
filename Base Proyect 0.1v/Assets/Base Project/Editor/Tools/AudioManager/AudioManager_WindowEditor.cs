using Managers;
using UnityEngine;

namespace UnityEditor {
    public class AudioManager_WindowEditor :EditorWindow
    {
        AudioManager audiomanager = null;

        private string find;

        private bool[,] show = new bool[1000,1000];

        private bool finder;

        Vector2 index = Vector2.zero ;

        [MenuItem("Tools/Audio Manager")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(AudioManager_WindowEditor), false, "Audio Manager");
        }

        void OnGUI()
        {
            if (audiomanager == null) audiomanager = FindObjectOfType<AudioManager>();

            if (audiomanager == null) return;

            //Finder
            EditorGUILayout.BeginVertical("box");
            {
                GUILayout.Label("Search", EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal();
                {
                    find = EditorGUILayout.TextArea(find);

                    if (find == "") finder = false;

                    {
                        Texture image = Resources.Load<Texture>("Search");

                        if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                        {
                            finder = true;
                            index = audiomanager.GetAudioFile(find);
                        }
                            
                    }
                }
                EditorGUILayout.EndHorizontal();

                if(finder)
                    DrawAudioFile(index);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(5);

            EditorGUILayout.BeginVertical("box");
            {               
                for (int j = 0; j < audiomanager.audioGroups.Count; j++)
                {
                    EditorGUILayout.BeginHorizontal();

                    show[j,999] = EditorGUILayout.BeginFoldoutHeaderGroup(show[j,999], audiomanager.audioGroups[j].groupName);

                    {
                        Texture image = Resources.Load<Texture>("Mas");

                        if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                        {
                            audiomanager.audioGroups[j].audioFiles.Add(new AudioFile());
                        }
                    }

                    EditorGUILayout.EndHorizontal();

                    if (show[j,999])
                    {
                        EditorGUILayout.Space(5);

                        audiomanager.audioGroups[j].groupName = EditorGUILayout.TextArea(audiomanager.audioGroups[j].groupName);
                        for (int i = 0; i < audiomanager.audioGroups[j].audioFiles.Count; i++)
                        {
                            EditorGUI.BeginChangeCheck();
                            EditorGUILayout.BeginVertical("box");
                            {
                                EditorGUILayout.BeginHorizontal();

                                show[j,i] = EditorGUILayout.Foldout(show[j,i], audiomanager.audioGroups[j].audioFiles[i].audioName);

                                {
                                    Texture image = Resources.Load<Texture>("Delete");

                                    if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                                    {
                                        audiomanager.audioGroups[j].audioFiles.RemoveAt(i);
                                    }
                                }

                                EditorGUILayout.EndHorizontal();

                                if (show[j,i])
                                {
                                    EditorGUILayout.Space(5);

                                    //Name
                                    {
                                        var serializedObject = new SerializedObject(audiomanager);
                                        var property = serializedObject.FindProperty("audioGroups");

                                        property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                                        FindPropertyRelative("audioName").stringValue =
                                        EditorGUILayout.TextArea(audiomanager.audioGroups[j].audioFiles[i].audioName);

                                        serializedObject.ApplyModifiedProperties();
                                    }

                                    EditorGUILayout.Space(10);

                                    //Volume
                                    {
                                        var serializedObject = new SerializedObject(audiomanager);
                                        var property = serializedObject.FindProperty("audioGroups");

                                        property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                                        FindPropertyRelative("volume").floatValue =
                                        EditorGUILayout.Slider("Volume", audiomanager.audioGroups[j].audioFiles[i].volume, 0f, 1f);

                                        serializedObject.ApplyModifiedProperties();
                                    }

                                    EditorGUILayout.Space(10);

                                    //Clips
                                    {
                                        var serializedObject = new SerializedObject(audiomanager);
                                        var property = serializedObject.FindProperty("audioGroups");

                                        int count = property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                                        FindPropertyRelative("audioClip").arraySize;

                                        if (count <= 0)
                                        {
                                            AudioClip clip = null;
                                            audiomanager.audioGroups[j].audioFiles[i].audioClip.Add(clip);
                                        }

                                        EditorGUILayout.BeginVertical("box");
                                        {
                                            GUILayout.Label("Audio clip");

                                            for (int n = 0; n < count; n++)
                                            {
                                                EditorGUILayout.BeginHorizontal();

                                                string clipName = "Clip";

                                                if (property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                                FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue != null)
                                                    clipName = property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                                FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue.name;

                                                property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                                FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue =
                                                EditorGUILayout.ObjectField(clipName, property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                                FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue, typeof(AudioClip), true);

                                                {
                                                    Texture image = Resources.Load<Texture>("Mas");

                                                    if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                                                    {
                                                        AudioClip clip = null;
                                                        audiomanager.audioGroups[j].audioFiles[i].audioClip.Add(clip);
                                                    }
                                                }

                                                {
                                                    Texture image = Resources.Load<Texture>("Delete");

                                                    if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                                                    {
                                                        audiomanager.audioGroups[j].audioFiles[i].audioClip.RemoveAt(n);
                                                    }
                                                }

                                                EditorGUILayout.EndHorizontal();
                                            }
                                        }
                                        EditorGUILayout.EndVertical();

                                        serializedObject.ApplyModifiedProperties();
                                    }

                                    EditorGUILayout.Space(10);

                                    //Looping
                                    {
                                        var serializedObject = new SerializedObject(audiomanager);
                                        var property = serializedObject.FindProperty("audioGroups");

                                        property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                                        FindPropertyRelative("isLooping").boolValue =
                                        EditorGUILayout.Toggle("Loop", audiomanager.audioGroups[j].audioFiles[i].isLooping);

                                        serializedObject.ApplyModifiedProperties();
                                    }

                                    //PlayOnAwake
                                    {
                                        var serializedObject = new SerializedObject(audiomanager);
                                        var property = serializedObject.FindProperty("audioGroups");

                                        property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                                        FindPropertyRelative("playOnAwake").boolValue =
                                        EditorGUILayout.Toggle("playOnAwake", audiomanager.audioGroups[j].audioFiles[i].playOnAwake);

                                        serializedObject.ApplyModifiedProperties();
                                    }

                                    EditorGUILayout.Space(10);

                                 
                                }
                            }
                            EditorGUILayout.EndVertical();
                            EditorGUI.EndChangeCheck();
                        }
                    }

                    EditorGUILayout.EndFoldoutHeaderGroup();
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawAudioFile(Vector2 index)
        {
            int j = (int)index.x;
            int i = (int)index.y;

            if (true)
            {
                EditorGUILayout.Space(5);

                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.BeginVertical("box");
                    {
                        EditorGUILayout.BeginHorizontal();

                        show[j, i] = EditorGUILayout.Foldout(show[j, i], audiomanager.audioGroups[j].audioFiles[i].audioName);

                        {
                            Texture image = Resources.Load<Texture>("Delete");

                            if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                            {
                                audiomanager.audioGroups[j].audioFiles.RemoveAt(i);
                            }
                        }

                        EditorGUILayout.EndHorizontal();

                    if (show[j, i])
                    {
                        EditorGUILayout.Space(5);

                        //Name
                        {
                            var serializedObject = new SerializedObject(audiomanager);
                            var property = serializedObject.FindProperty("audioGroups");

                            property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                            FindPropertyRelative("audioName").stringValue =
                            EditorGUILayout.TextArea(audiomanager.audioGroups[j].audioFiles[i].audioName);

                            serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUILayout.Space(10);

                        //Volume
                        {
                            var serializedObject = new SerializedObject(audiomanager);
                            var property = serializedObject.FindProperty("audioGroups");

                            property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                            FindPropertyRelative("volume").floatValue =
                            EditorGUILayout.Slider("Volume", audiomanager.audioGroups[j].audioFiles[i].volume, 0f, 1f);

                            serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUILayout.Space(10);

                        //Clips
                        {
                            var serializedObject = new SerializedObject(audiomanager);
                            var property = serializedObject.FindProperty("audioGroups");

                            int count = property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                            FindPropertyRelative("audioClip").arraySize;

                            if(count <= 0)
                            {
                                AudioClip clip = null;
                                audiomanager.audioGroups[j].audioFiles[i].audioClip.Add(clip);

                                count = 1;
                            }

                            EditorGUILayout.BeginVertical("box");
                            {
                                GUILayout.Label("Audio clip");

                                for (int n = 0; n < count; n++)
                                {
                                    EditorGUILayout.BeginHorizontal();

                                    property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                    FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue =
                                    EditorGUILayout.ObjectField("clip " + n.ToString(), property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).
                                    FindPropertyRelative("audioClip").GetArrayElementAtIndex(n).objectReferenceValue, typeof(AudioClip), true);

                                    {
                                        Texture image = Resources.Load<Texture>("Mas");

                                        if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                                        {
                                            AudioClip clip = null;
                                            audiomanager.audioGroups[j].audioFiles[i].audioClip.Add(clip);
                                        }
                                    }

                                    {
                                        Texture image = Resources.Load<Texture>("Delete");

                                        if (GUILayout.Button(image, GUILayout.Width(20), GUILayout.Height(20)))
                                        {
                                            audiomanager.audioGroups[j].audioFiles[i].audioClip.RemoveAt(n);
                                        }
                                    }

                                    EditorGUILayout.EndHorizontal();
                                }
                            }
                            EditorGUILayout.EndVertical();

                            serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUILayout.Space(10);

                        //Looping
                        {
                            var serializedObject = new SerializedObject(audiomanager);
                            var property = serializedObject.FindProperty("audioGroups");

                            property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                            FindPropertyRelative("isLooping").boolValue =
                            EditorGUILayout.Toggle("Loop", audiomanager.audioGroups[j].audioFiles[i].isLooping);

                            serializedObject.ApplyModifiedProperties();
                        }

                        //PlayOnAwake
                        {
                            var serializedObject = new SerializedObject(audiomanager);
                            var property = serializedObject.FindProperty("audioGroups");

                            property.GetArrayElementAtIndex(j).FindPropertyRelative("audioFiles").GetArrayElementAtIndex(i).

                            FindPropertyRelative("playOnAwake").boolValue =
                            EditorGUILayout.Toggle("playOnAwake", audiomanager.audioGroups[j].audioFiles[i].playOnAwake);

                            serializedObject.ApplyModifiedProperties();
                        }

                        EditorGUILayout.Space(10);
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUI.EndChangeCheck();
                }
            }
        }
    }
}