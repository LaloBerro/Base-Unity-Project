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
        public static bool MinimumDistance(this Vector3 v, Vector3 otherVector, float distance)
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
        public static bool MinimumDistance(this Vector2 v, Vector2 otherVector, float distance)
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
        public static bool MinimumDistance(this Vector3 v, Vector2 otherVector, float distance)
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
        public static bool MinimumDistance(this Vector2 v, Vector3 otherVector, float distance)
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
        public static bool MinimumOrEqualDistance(this Vector3 v, Vector3 otherVector, float distance)
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
        public static bool MinimumOrEqualDistance(this Vector2 v, Vector2 otherVector, float distance)
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
        public static bool MinimumOrEqualDistance(this Vector3 v, Vector2 otherVector, float distance)
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
        public static bool MinimumOrEqualDistance(this Vector2 v, Vector3 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumDistance(this Vector3 v, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) > distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumDistance(this Vector2 v, Vector2 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) > distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumDistance(this Vector3 v, Vector2 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) > distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumDistance(this Vector2 v, Vector3 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) > distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumOrEqualDistance(this Vector3 v, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) >= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumOrEqualDistance(this Vector2 v, Vector2 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) >= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumOrEqualDistance(this Vector3 v, Vector2 otherVector, float distance)
        {
            if (Vector3.Distance(v, otherVector) >= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is more than determined
        /// </summary>
        /// <param name="v"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MaximumOrEqualDistance(this Vector2 v, Vector3 otherVector, float distance)
        {
            if (Vector2.Distance(v, otherVector) >= distance)
                return true;

            return false;
        }
        #endregion

        #region Conevert

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

        #endregion

        #region Change a vector component

        /// <summary>
        /// Change X
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 ChangeX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Change Y
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector3 ChangeY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Change Z
        /// </summary>
        /// <param name="v"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 ChangeZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        /// <summary>
        /// Change X
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector2 ChangeX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        /// <summary>
        /// Change Y
        /// </summary>
        /// <param name="v"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector2 ChangeY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        #endregion

        #region Add value to component

        /// <summary>
        /// Add a value to x component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 AddX(this Vector3 v, float value)
        {
            return new Vector3(v.x + value, v.y, v.z);
        }

        /// <summary>
        /// Add a value to x component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 AddX(this Vector2 v, float value)
        {
            return new Vector2(v.x + value, v.y);
        }

        /// <summary>
        /// Add a value to y component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 AddY(this Vector3 v, float value)
        {
            return new Vector3(v.x , v.y + value, v.z);
        }

        /// <summary>
        /// Add a value to y component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 AddY(this Vector2 v, float value)
        {
            return new Vector2(v.x, v.y + value);
        }

        /// <summary>
        /// Add a value to z component
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 AddZ(this Vector3 v, float value)
        {
            return new Vector3(v.x, v.y, v.z + value);
        }

        /// <summary>
        /// Add a values to vector components
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 Add(this Vector3 v, float _x, float _y, float _z)
        {
            return new Vector3(v.x + _x, v.y + _y, v.z + _z);
        }

        /// <summary>
        /// Add a values to vector components
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 Add(this Vector2 v, float _x, float _y)
        {
            return new Vector2(v.x + _x, v.y + _y);
        }

        /// <summary>
        /// Add a values to vector components
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3 Add(this Vector3 v, Vector3 other)
        {
            return new Vector3(v.x + other.x, v.y + other.y, v.z + other.z);
        }

        /// <summary>
        /// Add a values to vector components
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2 Add(this Vector2 v, Vector2 other)
        {
            return new Vector2(v.x + other.x, v.y + other.y);
        }

        #endregion

        #region Math

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

        /// <summary>
        /// Interpolates between min and max with smoothing limits
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="to"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static Vector3 SmoothLerp(this Vector3 vector, Vector3 to, float speed)
        {
            Vector3 _vector = vector;
            _vector.x = Mathf.SmoothStep(_vector.x, to.x, speed * Time.deltaTime);
            _vector.y = Mathf.SmoothStep(_vector.y, to.y, speed * Time.deltaTime);
            _vector.z = Mathf.SmoothStep(_vector.z, to.z, speed * Time.deltaTime);

            return _vector;
        }

        #endregion
    }
}