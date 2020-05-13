using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class Tools
{
    /// <summary>
    /// Random sort of a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static List<T> RandomSort<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int index_1 = Random.Range(0, list.Count);
            int index_2 = Random.Range(0, list.Count);

            T temp = list[index_1];

            list[index_1] = list[index_2];
            list[index_2] = temp;
        }

        return list;
    }

    /// <summary>
    /// Random sort of an array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    public static T[] RandomSort<T>(this T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int random_index = Random.Range(0, array.Length);

            T temp = array[i];

            array[i] = array[random_index];
            array[random_index] = temp;
        }

        return array;
    }

    /// <summary>
    /// Retrun a random navmesh point
    /// </summary>
    /// <param name="_radius"></param>
    /// <returns></returns>
    public static Vector3 RandomNavmeshLocation(float _radius, Transform transform)
    {
        Vector3 randomDirection = Random.insideUnitSphere * _radius;
        randomDirection += transform.position;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}