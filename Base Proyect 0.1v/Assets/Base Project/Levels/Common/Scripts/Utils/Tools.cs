using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    /// <summary>
    /// Wait a determined time and ejecute a action
    /// </summary>
    /// <param name="time"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    private static IEnumerator WaitTimeAndThenRun(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}