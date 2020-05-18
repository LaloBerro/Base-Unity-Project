using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        /// <summary>
        /// Move a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveTowards(this Transform transform, Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        public static void MoveTowards(this Transform transform, Transform target, float speed)
        {
            MoveTowards(transform, target.position, speed);
        }

        /// <summary>
        /// Move with lerp a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveLerpTo(this Transform transform, Vector3 target, float speed)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
        public static void MoveLerpTo(this Transform transform, Transform target, float speed)
        {
            MoveLerpTo(transform, target.position, speed);
        }

        /// <summary>
        /// Rotate the transform to the target direction
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="axis"></param>
        public static void LookAt(this Transform transform, Transform target, Vector3 axis)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

            Quaternion LookAtRotationOnly_Y = Quaternion.Euler( 
                axis.x == 0 ? transform.rotation.eulerAngles.x : LookAtRotation.eulerAngles.x,
                axis.y == 0 ? transform.rotation.eulerAngles.y : LookAtRotation.eulerAngles.y,
                axis.z == 0 ? transform.rotation.eulerAngles.z : LookAtRotation.eulerAngles.z);

            transform.rotation = LookAtRotationOnly_Y;
        }

        /// <summary>
        /// A method for finding all objects of a certain type that are within a specific distance from a Transform
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="transform"></param>
        /// <param name="proximity"></param>
        /// <returns></returns>
        public static List<T> FindObjectsWithinProximity<T>(this Transform transform, float proximity) where T : MonoBehaviour
        {
            List<T> objects = new List<T>();

            T[] foundObjects = GameObject.FindObjectsOfType<T>();
            for (int x = 0; x < foundObjects.Length; x++)
            {
                T obj = foundObjects[x];
                if ((obj.transform.position - transform.position).magnitude <= proximity)
                    objects.Add(obj);
            }

            return objects;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Transform transform, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(transform.position, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherTransform"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Transform transform, Transform otherTransform, float distance)
        {
            if (Vector3.Distance(transform.position, otherTransform.position) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Transform transform, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(transform.position, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherTransform"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Transform transform, Transform otherTransform, float distance)
        {
            if (Vector3.Distance(transform.position, otherTransform.position) <= distance)
                return true;

            return false;
        }
    }
}