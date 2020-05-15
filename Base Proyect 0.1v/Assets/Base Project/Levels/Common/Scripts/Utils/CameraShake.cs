using UnityEngine;
using System.Collections;

namespace Utils
{
    public class CameraShake : MonoBehaviour
    {
        public float duration;
        public float amount;

        private Vector3 _originalPos;

        public void Shake()
        {
            StartCoroutine(_Shake());
        }

        public IEnumerator _Shake()
        {
            _originalPos = transform.localPosition;

            float endTime = Time.time + duration;

            while (Time.time < endTime)
            {
                transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

                yield return null;
            }

            transform.localPosition = _originalPos;
        }
    }
}