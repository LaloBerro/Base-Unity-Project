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
    }
}