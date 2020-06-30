using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace EditorTool
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Transform))]
    class TransformEditor : Editor
    {
        SerializedProperty m_LocalPosition;
        SerializedProperty m_LocalRotation;
        SerializedProperty m_LocalScale;
        object m_TransformRotationGUI;

        void OnEnable()
        {
            m_LocalPosition = serializedObject.FindProperty("m_LocalPosition");
            m_LocalRotation = serializedObject.FindProperty("m_LocalRotation");
            m_LocalScale = serializedObject.FindProperty("m_LocalScale");

            if (m_TransformRotationGUI == null)
            {
                m_TransformRotationGUI = System.Activator.CreateInstance(typeof(SerializedProperty).Assembly.GetType("UnityEditor.TransformRotationGUI", false, false));
            }

            m_TransformRotationGUI.GetType().GetMethod("OnEnable")?.Invoke(m_TransformRotationGUI, new object[] { m_LocalRotation, new GUIContent("Rotation") });
        }

        public override void OnInspectorGUI()
        {
            SerializedObject serObj = serializedObject;

            serObj.Update();

            DrawLocalPosition();
            DrawLocalRotation();
            DrawLocalScale();

            DrawPropertiesExcluding(serObj, "m_LocalPosition", "m_LocalRotation", "m_LocalScale");

            Verify();

            serObj.ApplyModifiedProperties();
        }

        void DrawLocalPosition()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PropertyField(m_LocalPosition, new GUIContent("Position"));

                if (GUILayout.Button(new GUIContent("C", "Set parent position to center of children"), EditorStyles.miniButton, GUILayout.Width(21)))
                {
                    CenterParentToChildren();
                }

                if (GUILayout.Button(new GUIContent("P", "Reset Position"), EditorStyles.miniButton, GUILayout.Width(21)))
                {
                    m_LocalPosition.vector3Value = Vector3.zero;
                }
            }
        }

        void DrawLocalRotation()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                m_TransformRotationGUI.GetType().GetMethod("RotationField", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null)
                                      .Invoke(m_TransformRotationGUI, new object[] { false });

                GUILayout.Space(22);

                if (GUILayout.Button(new GUIContent("R", "Reset Rotation"), EditorStyles.miniButton, GUILayout.Width(21)))
                    m_LocalRotation.quaternionValue = Quaternion.identity;
            }
        }

        void DrawLocalScale()
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PropertyField(m_LocalScale, new GUIContent("Scale"));

                GUILayout.Space(22);

                if (GUILayout.Button(new GUIContent("S", "Reset Scale"), EditorStyles.miniButton, GUILayout.Width(21)))
                    m_LocalScale.vector3Value = Vector3.one;
            }
        }

        void Verify()
        {
            var transform = target as Transform;
            var position = transform.position;
            if (Mathf.Abs(position.x) > 100000f || Mathf.Abs(position.y) > 100000f || Mathf.Abs(position.z) > 100000f)
                EditorGUILayout.HelpBox("Due to floating-point precision limitations, it is recommended to bring the world coordinates of the GameObject within a smaller range.", MessageType.Warning);
        }

        private void CenterParentToChildren()
        {
            foreach (Object targetObject in targets)
            {
                if (targetObject == null)
                {
                    continue;
                }

                var thisTransform = targetObject as Transform;
                if (thisTransform == null || thisTransform.childCount < 1)
                {
                    continue;
                }

                SerializedObject[] children = new SerializedObject[thisTransform.childCount];

                for (int i = 0; i < thisTransform.childCount; i++)
                {
                    children[i] = new SerializedObject(thisTransform.GetChild(i));
                }

                Vector3 average = Vector3.zero;

                for (int i = 0; i < children.Length; i++)
                {
                    Vector3 pos = children[i].FindProperty("m_LocalPosition").vector3Value;
                    average += pos;
                }

                average /= children.Length;
                var thisTransformObject = new SerializedObject(thisTransform);
                thisTransformObject.FindProperty("m_LocalPosition").vector3Value += average;
                thisTransformObject.ApplyModifiedProperties();

                for (int i = 0; i < children.Length; i++)
                {
                    children[i].FindProperty("m_LocalPosition").vector3Value = (average - children[i].FindProperty("m_LocalPosition").vector3Value) * -1;
                    children[i].ApplyModifiedProperties();
                }
            }
        }
    }
}