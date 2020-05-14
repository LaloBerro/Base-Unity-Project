using System.Collections;
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
    }
}