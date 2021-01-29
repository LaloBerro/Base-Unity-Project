using UnityEngine;

namespace Common.Utils.Transform
{
    public class Rotate : MonoBehaviour
    {
        [Header("Config")]
        public float speed;
        public Vector3 direction;

        private void Update()
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }
    }
}