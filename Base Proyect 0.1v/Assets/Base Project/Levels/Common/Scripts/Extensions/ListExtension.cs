using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Random sort of a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static List<T> RandomSort<T>(this List<T> list)
        {
            List<T> newList = new List<T>();

            while (list.Count > 0)
            {
                T item = list[Random.Range(0, list.Count)];
                list.Remove(item);

                newList.Add(item);
            }

            return newList;
        }
    }
}