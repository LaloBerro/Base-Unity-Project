using System.Collections;
using UnityEngine;

public static class Tools
{
    #region Time 

    /// <summary>
    /// Wait a determined time and ejecute a action
    /// </summary>
    /// <param name="mb"></param>
    /// <param name="time"></param>
    /// <param name="callback"></param>
    public static void WaitTimeAndThenRun(this MonoBehaviour mb,float time, System.Action callback)
    {
        mb.StartCoroutine(WaitTimeAndThenRun(time, callback));
    }

    private static IEnumerator WaitTimeAndThenRun(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    #endregion
}