using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor {
    public class SetCorrectPosition_Editor : EditorWindow
    {
        public LayerMask mask;

        private float offset;

        private bool affectRotation;

        [MenuItem("Tools/Position Corrector")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(SetCorrectPosition_Editor), false, "Position Corrector");
        }

        void OnGUI()
        {          
            EditorGUILayout.BeginVertical("box");

            affectRotation = EditorGUILayout.Toggle("Affect rotation", affectRotation);

            EditorGUILayout.LabelField("LayerMask");
            LayerMask tempMask = EditorGUILayout.MaskField(InternalEditorUtility.LayerMaskToConcatenatedLayersMask(mask), InternalEditorUtility.layers);
            mask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask);

            EditorGUILayout.LabelField("Buried level");
            offset = EditorGUILayout.FloatField(offset);

            EditorGUILayout.EndVertical();

            if (GUILayout.Button("Set"))
            {
                SetPositions(Selection.gameObjects);
            }
        }

        private void SetPositions(GameObject[] gos)
        {
            for (int i = 0; i < gos.Length; i++)
            {
                Undo.RecordObject(gos[i].transform, "position");

                if (affectRotation)
                    gos[i].transform.rotation = GetRotation(gos[i].transform);

                gos[i].transform.position = GetPosition(gos[i].transform) + (affectRotation ? new Vector3(0,offset,0) : Vector3.zero);

                EditorUtility.SetDirty(gos[i]);               
            }
        }

        private Vector3 GetPosition(Transform go)
        {
            if(Physics.Raycast(go.position, Vector3.down * 10,out RaycastHit hit,1000, mask))
            {
                return hit.point + hit.normal.normalized * offset;
            }

            return go.position;
        }       

        private Quaternion GetRotation(Transform go)
        {          
            if (Physics.Raycast(go.position, Vector3.down * 10, out RaycastHit hit, 1000, mask))
            {
                return Quaternion.FromToRotation(Vector3.up, hit.normal); ;
            }

            return go.rotation;
        }
    }
}