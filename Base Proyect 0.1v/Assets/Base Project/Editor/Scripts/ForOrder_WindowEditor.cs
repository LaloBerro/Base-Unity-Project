using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor
{
    public class ForOrder_WindowEditor : EditorWindow
    {
        #region VAR

        public enum Mode
        {
            PARENT,
            GROUP,
        }

        public enum SortModes
        {
            SELECTION,
            CHILDREN,
            SCENE,
        }

        public Mode sortMode;
        
        public SortModes mode;

        public Transform globalParent = null;

        public bool parentIsSelection;

        public string startWith;

        public bool sortByIndex;

        #endregion

        [MenuItem("Tools/Sort Inspector")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(ForOrder_WindowEditor), false, "Sort Inspector");
        }

        void OnGUI()
        {
            EditorGUILayout.Space(10);

            sortMode = (Mode)EditorGUILayout.EnumPopup("Sort mode", sortMode);

            GUILayout.Box(GUIContent.none, "horizontalSlider");

            EditorGUILayout.Space(10);

            switch (sortMode)
            {
                case Mode.PARENT:
                    ReParentWindow();
                    break;
                case Mode.GROUP:
                    GroupWindow();
                    break;
            }
        }

        #region Windows

        private void DrawModes()
        {
            EditorGUILayout.BeginVertical("TextArea");
            {
                switch (mode)
                {
                    case SortModes.SELECTION:
                        DrawSelection();
                        break;

                    case SortModes.CHILDREN:
                        DrawChildren();
                        break;

                    case SortModes.SCENE:
                        DrawScene();
                        break;

                    default:
                        break;
                }
            }
        }

        private void ReParentWindow()
        {
            EditorGUILayout.BeginVertical("box");
            {
                mode = (SortModes)EditorGUILayout.EnumPopup("Mode", mode);

                EditorGUILayout.Space(3);

                sortByIndex = EditorGUILayout.Toggle("Index affect sort", sortByIndex);

                DrawModes();

                EditorGUILayout.EndVertical();

                EditorGUILayout.Space(3);
            }
            EditorGUILayout.EndVertical();
        }

        private void GroupWindow()
        {
            EditorGUILayout.BeginVertical("box");
            {
                mode = (SortModes)EditorGUILayout.EnumPopup("Mode", mode);

                EditorGUILayout.Space(3);

                EditorGUILayout.LabelField("Group objects that start with");
                startWith = EditorGUILayout.TextArea(startWith);

                EditorGUILayout.Space(3);

                DrawModes();

                EditorGUILayout.EndVertical();

                EditorGUILayout.Space(3);
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        #region DrawModes

        private void DrawSelection()
        {
            SetGlobalParent();

            if (globalParent == null) return;

            EditorGUILayout.Space(3);

            if (GUILayout.Button("Sort"))
            {               
                SelectionMode();
            }
        }
        private void DrawChildren()
        {
            parentIsSelection = EditorGUILayout.Toggle("Parent is selected", parentIsSelection);

            if (parentIsSelection)
            {
                globalParent = Selection.activeTransform;

                if(globalParent == null)
                {
                    GUI.color = Color.red;
                    {
                        EditorGUILayout.LabelField("Select a parent");
                    }
                    GUI.color = Color.white;
                }
            }
            else
            {
                SetGlobalParent();
            }

            if (globalParent == null) return;

            EditorGUILayout.Space(3);

            if (GUILayout.Button("Sort"))
            {             
                ChildrenMode();
            }
        }
        private void DrawScene()
        {
            if (GUILayout.Button("Sort"))
            {
                SceneMode();
            }
        }

        private void SetGlobalParent()
        {
            EditorGUILayout.Space(3);

            if (globalParent == null)
            {
                EditorGUILayout.BeginVertical("box");
                {
                    GUI.color = Color.red;
                    {
                        EditorGUILayout.LabelField("Insert a parent");
                    }
                    GUI.color = Color.white;

                    globalParent = (Transform)EditorGUILayout.ObjectField("Parent ", globalParent, typeof(Transform), true);
                }
                EditorGUILayout.EndVertical();

                return;
            }

            globalParent = (Transform)EditorGUILayout.ObjectField("Parent ", globalParent, typeof(Transform), true);
        }

        #endregion

        #region SortModes
        private void SelectionMode()
        {
            List<GameObject> objectsToOrder = new List<GameObject>(Selection.gameObjects);

            if (sortMode == Mode.PARENT)
                Sort(objectsToOrder);
            else
                Group(objectsToOrder);
        }
        private void ChildrenMode()
        {
            List<GameObject> objectsToOrder = new List<GameObject>();

            Transform selected = Selection.activeGameObject.transform;

            for (int i = 0; i < selected.childCount; i++)
            {
                objectsToOrder.Add(selected.GetChild(i).gameObject);
            }

            if (sortMode == Mode.PARENT)
                Sort(objectsToOrder);
            else
                Group(objectsToOrder);
        }
        private void SceneMode()
        {
            GameObject[] allGO = FindObjectsOfType<GameObject>();

            List<GameObject> objectsToOrder = new List<GameObject>(allGO);

            if (sortMode == Mode.PARENT)
                Sort(objectsToOrder, false);
            else
                Group(objectsToOrder, false);
        }

        private void Sort(List<GameObject> objectsToOrder, bool isGlobalParent = true)
        {
            //Hasta que todos los objetos esten ordenados
            while (objectsToOrder.Count > 0)
            {
                //Parent of the objects with same name
                string parentName = CorrectName(objectsToOrder[0].name);

                //Create a parent
                GameObject parent = new GameObject(parentName);

                //The objects re parent to contains alls
                if(isGlobalParent)
                    parent.transform.SetParent(globalParent);

                //Undo operation
                Undo.RegisterCreatedObjectUndo(parent, "order");

                for (int i = 0; i < objectsToOrder.Count; i++)
                {
                    //if (IsTheSameName(parentName, objectsToOrder[i].name) == false) continue;
                    if (CorrectName(objectsToOrder[i].name) != parentName) continue;

                    Undo.SetTransformParent(objectsToOrder[i].transform, parent.transform, "order");

                    objectsToOrder[i].transform.SetParent(parent.transform);

                    objectsToOrder.RemoveAt(i);

                    i--;
                }
            }
        }

        private void Group(List<GameObject> objectsToGroup, bool isGlobalParent = true)
        {
            //Parent of the objects with same name
            string parentName = startWith;

            //Create a parent
            GameObject parent = new GameObject(parentName);

            //The objects re parent to contains alls
            if (isGlobalParent)
                parent.transform.SetParent(globalParent);

            //Undo operation
            Undo.RegisterCreatedObjectUndo(parent, "order");
            Undo.SetTransformParent(objectsToGroup[0].transform, parent.transform, "order");

            //Hasta que todos los objetos esten ordenados
            while (objectsToGroup.Count > 0)
            {
                if (StartWithThis(parentName, objectsToGroup[0].name) == false)
                {
                    objectsToGroup.RemoveAt(0);
                    continue;
                }

                Undo.SetTransformParent(objectsToGroup[0].transform, parent.transform, "order");

                objectsToGroup[0].transform.SetParent(parent.transform);

                objectsToGroup.RemoveAt(0);
            }
        }

        #endregion

        #region Names

        /// <summary>
        /// If the name contains index (ex: (1), (33)) remove them
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        private string CorrectName(string _name)
        {
            if (sortByIndex) return _name;

            char finalChar = _name[_name.Length - 1];
            string correctName = _name;

            if (finalChar == ')')
                correctName = ParenthesisSyntax(_name);
            else if (char.IsDigit(finalChar))
                correctName = DigitSyntax(_name);

            return correctName;
        }

        private string ParenthesisSyntax(string _name)
        {
            int numbers = NumberQuant(_name.TrimEnd(')')) + 2;

            if (_name[_name.Length - numbers] == '(')
            {
                string newName = "";

                for (int i = 0; i < _name.Length - (numbers + 1); i++)
                {
                    newName += _name[i];
                }
                return newName;
            }

            return _name;
        }

        private string DigitSyntax(string _name)
        {
            string newName = "";
            int numbers = NumberQuant(_name);

            for (int i = 0; i < _name.Length - numbers; i++)
            {
                newName += _name[i];
            }

            return newName;

        }

        private int NumberQuant(string _name)
        {
            int numbers = 0;
            for (int i = _name.Length - 1; i > 0; i--)
            {
                if (char.IsDigit(_name[i]))
                    numbers++;

                else break;
            }

            return numbers;
        }

        private bool StartWithThis(string _startWith, string compareName)
        {
            if (compareName.Length < _startWith.Length) return false;

            for (int i = 0; i < _startWith.Length; i++)
            {
                if (compareName[i] != _startWith[i]) return false;               
            }

            return true;
        }

        #endregion
    }
}