using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Return a random item in array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T randomItem<T>(this T[] array)
        {
            return array[Mathf.FloorToInt(Random.value * array.Length)];
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
        /// For each component in an array, take an action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="callback">The action to take</param>
        public static void ForEachComponent<T>(this T[] array, System.Action<T> callback) where T : Component
        {
            for (var i = 0; i < array.Length; i++)
            {
                callback.Invoke(array[i]);
            }
        }

        public static List<T> ToList<T>(this T[] array) where T : class
        {
            List<T> output = new List<T>();
            output.AddRange(array);
            return output;
        }
    }
}