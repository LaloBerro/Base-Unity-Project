using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace UnityEditor
{
    public class EditorToolSpaceSelector : Editor
    {
        private static bool gizmos;

        [MenuItem("Tools/HotKeys/Transform space")]
        static void DoSomethingWithAShortcutKey()
        {
            Tools.current = Tool.Move;
            Debug.Log("Doing something with a Shortcut Key...");
        }

        [Shortcut("MyCustomAsset/Add MyCustomComponent", null, KeyCode.Space)]
        public static void AddComponentToSelectedGameObject(ShortcutArguments shortcutArguments)
        {
            switch (Tools.current)
            {
                case Tool.View:
                    Tools.current = Tool.Move;

                    break;
                case Tool.Move:
                    Tools.current = Tool.Rotate;

                    break;

                case Tool.Rotate:
                    Tools.current = Tool.Scale;

                    break;

                case Tool.Scale:
                    Tools.current = Tool.Move;

                    break;

                case Tool.Rect:
                    Tools.current = Tool.Move;

                    break;

                case Tool.Transform:
                    Tools.current = Tool.Move;

                    break;

                case Tool.Custom:
                    Tools.current = Tool.Move;

                    break;

                case Tool.None:
                    Tools.current = Tool.Move;

                    break;

                default:
                    Tools.current = Tool.Move;

                    break;
            }
        }

        [Shortcut("MyCustomAsset/Add MyCustomComponent 2", null, KeyCode.C)]
        public static void DeselectAll(ShortcutArguments shortcutArguments)
        {
            Selection.activeObject = null;

            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                Selection.gameObjects[i] = null;
            }
        }
    }
}