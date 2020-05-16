using System.Collections;
using UnityEngine;

namespace Extensions
{
    public static class IEnumeratorExtension
    {
        /// <summary>
        /// Wait a determined time and ejecute a action
        /// </summary>
        /// <param name="time"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IEnumerator WaitTimeAndThenRun(float time, System.Action callback)
        {
            yield return new WaitForSeconds(time);
            callback.Invoke();
        }
    }
}