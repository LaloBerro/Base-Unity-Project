using UnityEngine;

namespace Extensions
{
    public static class VectorExtension
    {
        #region Distace Comparations
        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Vector3 v, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Vector2 v, Vector2 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Vector3 v, Vector2 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunDistance(this Vector2 v, Vector3 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Vector3 v, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Vector2 v, Vector2 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Vector3 v, Vector2 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimunOrEqualDistance(this Vector2 v, Vector3 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) <= distance)
                return true;

            return false;
        }
        #endregion

        /// <summary>
        /// Convert Vector3 in Vector2
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        /// <summary>
        /// Convert Vector2 to vector3
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this Vector2 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Change X
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 SwapX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Change Y
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 SwapY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Change Z
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 SwapZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Change X
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 SwapX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        /// <summary>
        /// Change Y
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 SwapY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        /// <summary>
        /// Return a angle between vectors
        /// </summary>
        /// <param name="v"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float GetAngleToVector(this Vector3 v, Vector3 vector)
        {
            float deltaY = vector.y - v.y;
            float deltaX = vector.x - v.x;

            //0 will be the vector directly to the left of the point
            return Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI + 180;
        }

        /// <summary>
        /// Return a angle between vectors
        /// </summary>
        /// <param name="v"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float GetAngleToVector(this Vector2 v, Vector2 vector)
        {
            float deltaY = vector.y - v.y;
            float deltaX = vector.x - v.x;

            //0 will be the vector directly to the left of the point
            return Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI + 180;
        }

        /// <summary>
        /// Turn the vector in degree (only in xy)
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector3 Rotate(this Vector3 vector, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = vector.x;
            float ty = vector.y;
            vector.x = (cos * tx) - (sin * ty);
            vector.y = (sin * tx) + (cos * ty);
            return vector;
        }

        /// <summary>
        /// Turn the vector in degree
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 vector, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = vector.x;
            float ty = vector.y;
            vector.x = (cos * tx) - (sin * ty);
            vector.y = (sin * tx) + (cos * ty);
            return vector;
        }
    }
}