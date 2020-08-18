using UnityEngine;

namespace Tool
{
    public static class ExtraGizmos
    {
        public static Color DefaultColor { get; set; }
        public static Matrix4x4 matrix => Gizmos.matrix;

        private static Color oldColor;

        static ExtraGizmos()
        {
            DefaultColor = Color.white;
        }

        private static void SwapColor(Color? c)
        {
            oldColor = Gizmos.color;
            Gizmos.color = c ?? DefaultColor;
        }
        private static void RestoreColor()
        {
            Gizmos.color = oldColor;
        }

        #region points and lines

        public static void DrawPoint(Vector3 position, Color? color = null, float scale = 1.0f)
        {
            SwapColor(color);
            Gizmos.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale);
            Gizmos.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale);
            Gizmos.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale);
            RestoreColor();
        }

        public static void DrawLine(Vector3 from, Vector3 to, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawLine(from, to);
            RestoreColor();
        }

        public static void DrawRay(Ray r, Color? color)
        {
            SwapColor(color);
            Gizmos.DrawLine(r.origin, r.origin + r.direction);
            RestoreColor();
        }

        public static void DrawRay(Vector3 from, Vector3 direction, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawLine(from, from + direction);
            RestoreColor();
        }

        #endregion

        #region 3D shapes

        public static void DrawWireSphere(Vector3 center, float radius = 1, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawWireSphere(center, radius);
            RestoreColor();
        }

        public static void DrawSphere(Vector3 center, float radius = 1, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawSphere(center, radius);
            RestoreColor();
        }

        public static void DrawWireCube(Vector3 center, Vector3? size = null, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawWireCube(center, size ?? Vector3.one);
            RestoreColor();
        }

        public static void DrawCube(Vector3 center, Vector3? size = null, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawCube(center, size ?? Vector3.one);
            RestoreColor();
        }

        public static void DrawLocalCube(Transform transform, Vector3? size = null, Color? color = null, Vector3? center = null)
        {
            SwapColor(color);

            Vector3 c = center ?? Vector3.zero;
            Vector3 sizeV = size ?? Vector3.one;

            Vector3 lbb = transform.TransformPoint(c - sizeV * 0.5f);
            Vector3 rbb = transform.TransformPoint(c + new Vector3(sizeV.x, -sizeV.y, -sizeV.z) * 0.5f);

            Vector3 lbf = transform.TransformPoint(c + new Vector3(sizeV.x, -sizeV.y, sizeV.z) * 0.5f);
            Vector3 rbf = transform.TransformPoint(c + new Vector3(-sizeV.x, -sizeV.y, sizeV.z) * 0.5f);

            Vector3 lub = transform.TransformPoint(c + new Vector3(-sizeV.x, sizeV.y, -sizeV.z) * 0.5f);
            Vector3 rub = transform.TransformPoint(c + new Vector3(sizeV.x, sizeV.y, -sizeV.z) * 0.5f);

            Vector3 luf = transform.TransformPoint(c + sizeV * 0.5f);
            Vector3 ruf = transform.TransformPoint(c + new Vector3(-sizeV.x, sizeV.y, sizeV.z) * 0.5f);

            Gizmos.DrawLine(lbb, rbb);
            Gizmos.DrawLine(rbb, lbf);
            Gizmos.DrawLine(lbf, rbf);
            Gizmos.DrawLine(rbf, lbb);

            Gizmos.DrawLine(lub, rub);
            Gizmos.DrawLine(rub, luf);
            Gizmos.DrawLine(luf, ruf);
            Gizmos.DrawLine(ruf, lub);

            Gizmos.DrawLine(lbb, lub);
            Gizmos.DrawLine(rbb, rub);
            Gizmos.DrawLine(lbf, luf);
            Gizmos.DrawLine(rbf, ruf);

            Gizmos.color = oldColor;
        }

        public static void DrawLocalCube(Matrix4x4 space, Vector3? size = null, Color? color = null, Vector3? center = null)
        {
            SwapColor(color);

            Vector3 c = center ?? Vector3.zero;
            Vector3 sizeV = size ?? Vector3.one;

            Vector3 lbb = space.MultiplyPoint3x4(c - sizeV * 0.5f);
            Vector3 rbb = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, -sizeV.y, -sizeV.z) * 0.5f);

            Vector3 lbf = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, -sizeV.y, sizeV.z) * 0.5f);
            Vector3 rbf = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, -sizeV.y, sizeV.z) * 0.5f);

            Vector3 lub = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, sizeV.y, -sizeV.z) * 0.5f);
            Vector3 rub = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, sizeV.y, -sizeV.z) * 0.5f);

            Vector3 luf = space.MultiplyPoint3x4(c + sizeV) * 0.5f;
            Vector3 ruf = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, sizeV.y, sizeV.z) * 0.5f);

            Gizmos.DrawLine(lbb, rbb);
            Gizmos.DrawLine(rbb, lbf);
            Gizmos.DrawLine(lbf, rbf);
            Gizmos.DrawLine(rbf, lbb);

            Gizmos.DrawLine(lub, rub);
            Gizmos.DrawLine(rub, luf);
            Gizmos.DrawLine(luf, ruf);
            Gizmos.DrawLine(ruf, lub);

            Gizmos.DrawLine(lbb, lub);
            Gizmos.DrawLine(rbb, rub);
            Gizmos.DrawLine(lbf, luf);
            Gizmos.DrawLine(rbf, ruf);

            RestoreColor();
        }

        public static void DrawFrustum(Vector3 center, float fov, float maxRange = 100, float minRange = 0.1f, float aspect = 16 / 9, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect);
            RestoreColor();
        }

        public static void DrawBounds(Bounds bounds, Color? color = null)
        {
            SwapColor(color);

            Vector3 center = bounds.center;

            float x = bounds.extents.x;
            float y = bounds.extents.y;
            float z = bounds.extents.z;

            Vector3 ruf = center + new Vector3(x, y, z);
            Vector3 rub = center + new Vector3(x, y, -z);
            Vector3 luf = center + new Vector3(-x, y, z);
            Vector3 lub = center + new Vector3(-x, y, -z);

            Vector3 rdf = center + new Vector3(x, -y, z);
            Vector3 rdb = center + new Vector3(x, -y, -z);
            Vector3 lfd = center + new Vector3(-x, -y, z);
            Vector3 lbd = center + new Vector3(-x, -y, -z);

            Gizmos.DrawLine(ruf, luf);
            Gizmos.DrawLine(ruf, rub);
            Gizmos.DrawLine(luf, lub);
            Gizmos.DrawLine(rub, lub);

            Gizmos.DrawLine(ruf, rdf);
            Gizmos.DrawLine(rub, rdb);
            Gizmos.DrawLine(luf, lfd);
            Gizmos.DrawLine(lub, lbd);

            Gizmos.DrawLine(rdf, lfd);
            Gizmos.DrawLine(rdf, rdb);
            Gizmos.DrawLine(lfd, lbd);
            Gizmos.DrawLine(lbd, rdb);

            RestoreColor();
        }

        public static void DrawCylinder(Vector3 start, Vector3? end = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 endPoint = end ?? (start + Vector3.up);
            Vector3 up = (endPoint - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

            //Radial circles
            DrawCircle(start, up, radius, color);
            DrawCircle(endPoint, -up, radius, color);
            DrawCircle((start + endPoint) * 0.5f, up, radius, color);

            //Side lines
            Gizmos.DrawLine(start + right, endPoint + right);
            Gizmos.DrawLine(start - right, endPoint - right);

            Gizmos.DrawLine(start + forward, endPoint + forward);
            Gizmos.DrawLine(start - forward, endPoint - forward);

            //Start endcap
            Gizmos.DrawLine(start - right, start + right);
            Gizmos.DrawLine(start - forward, start + forward);

            //End endcap
            Gizmos.DrawLine(endPoint - right, endPoint + right);
            Gizmos.DrawLine(endPoint - forward, endPoint + forward);

            RestoreColor();
        }

        public static void DrawCone(Vector3 position, Vector3? direction = null, float angle = 45, Color? color = null)
        {
            SwapColor(color);

            Vector3 dir = direction ?? Vector3.up;
            float length = dir.magnitude;

            Vector3 _forward = dir;
            Vector3 _up = Vector3.Slerp(_forward, -_forward, 0.5f);
            Vector3 _right = Vector3.Cross(_forward, _up).normalized * length;

            dir = dir.normalized;

            Vector3 slerpedVector = Vector3.Slerp(_forward, _up, angle / 90.0f);

            float dist;
            Plane farPlane = new Plane(-dir, position + _forward);
            Ray distRay = new Ray(position, slerpedVector);

            farPlane.Raycast(distRay, out dist);

            Gizmos.DrawRay(position, slerpedVector.normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, -_up, angle / 90.0f).normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, _right, angle / 90.0f).normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, -_right, angle / 90.0f).normalized * dist);

            DrawCircle(position + _forward, dir, (_forward - (slerpedVector.normalized * dist)).magnitude, color);
            DrawCircle(position + (_forward * 0.5f), dir, ((_forward * 0.5f) - (slerpedVector.normalized * (dist * 0.5f))).magnitude, color);

            RestoreColor();
        }

        public static void DrawCapsule(Vector3 start, Vector3? end = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 endPoint = end ?? (start + Vector3.up);

            Vector3 up = (endPoint - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

            float height = (start - endPoint).magnitude;
            float sideLength = Mathf.Max(0, (height * 0.5f) - radius);
            Vector3 middle = (endPoint + start) * 0.5f;

            start = middle + ((start - middle).normalized * sideLength);
            endPoint = middle + ((endPoint - middle).normalized * sideLength);

            //Radial circles
            DrawCircle(start, up, radius, color);
            DrawCircle(endPoint, -up, radius, color);


            //Side lines
            Gizmos.DrawLine(start + right, endPoint + right);
            Gizmos.DrawLine(start - right, endPoint - right);

            Gizmos.DrawLine(start + forward, endPoint + forward);
            Gizmos.DrawLine(start - forward, endPoint - forward);

            for (int i = 1; i < 26; i++)
            {

                //Start endcap
                Gizmos.DrawLine(Vector3.Slerp(right, -up, i / 25.0f) + start, Vector3.Slerp(right, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(-right, -up, i / 25.0f) + start, Vector3.Slerp(-right, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(forward, -up, i / 25.0f) + start, Vector3.Slerp(forward, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(-forward, -up, i / 25.0f) + start, Vector3.Slerp(-forward, -up, (i - 1) / 25.0f) + start);

                //End endcap
                Gizmos.DrawLine(Vector3.Slerp(right, up, i / 25.0f) + endPoint, Vector3.Slerp(right, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(-right, up, i / 25.0f) + endPoint, Vector3.Slerp(-right, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(forward, up, i / 25.0f) + endPoint, Vector3.Slerp(forward, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(-forward, up, i / 25.0f) + endPoint, Vector3.Slerp(-forward, up, (i - 1) / 25.0f) + endPoint);
            }

            RestoreColor();
        }

        public static void Draw3DArrow(Vector3 position, Vector3 direction, float? coneSize = 0.333f, Color? color = null)
        {
            SwapColor(color);

            Gizmos.DrawRay(position, direction);
            DrawCone(position + direction, -direction * coneSize, 15, color);

            RestoreColor();
        }

        #endregion

        #region meshes

        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawMesh(mesh, position, r, s);
            RestoreColor();
        }

        public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawMesh(mesh, submeshIndex, position, r, s);
            RestoreColor();
        }

        public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawWireMesh(mesh, position, r, s);
            RestoreColor();
        }

        public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawWireMesh(mesh, submeshIndex, position, r, s);
            RestoreColor();
        }

        #endregion

        #region 2D shapes

        public static void DrawCircle(Vector3 position, Vector3? up = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 upVector = (!up.HasValue || up.Value == Vector3.zero ? Vector3.up : up.Value).normalized * radius;

            Vector3 forward = Vector3.Slerp(upVector, -upVector, 0.5f);
            Vector3 right = Vector3.Cross(upVector, forward).normalized * radius;

            Matrix4x4 matrix = new Matrix4x4
            {
                [0] = right.x,
                [1] = right.y,
                [2] = right.z,
                [4] = upVector.x,
                [5] = upVector.y,
                [6] = upVector.z,
                [8] = forward.x,
                [9] = forward.y,
                [10] = forward.z
            };

            Vector3 lastPoint = position + matrix.MultiplyPoint3x4(new Vector3(Mathf.Cos(0), 0, Mathf.Sin(0)));
            Vector3 nextPoint = Vector3.zero;

            for (int i = 0; i < 91; i++)
            {
                nextPoint.x = Mathf.Cos((i * 4) * Mathf.Deg2Rad);
                nextPoint.z = Mathf.Sin((i * 4) * Mathf.Deg2Rad);
                nextPoint.y = 0;

                nextPoint = position + matrix.MultiplyPoint3x4(nextPoint);

                Gizmos.DrawLine(lastPoint, nextPoint);
                lastPoint = nextPoint;
            }

            RestoreColor();
        }

        public static void DrawPlanarArrow(Vector3 pos, Vector3 direction, float arrowheadLength = 0.25f, float angle = 20.0f, Color? color = null)
        {
            SwapColor(color);

            Gizmos.DrawRay(pos, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + angle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - angle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(pos + direction, right * arrowheadLength);
            Gizmos.DrawRay(pos + direction, left * arrowheadLength);

            RestoreColor();
        }

        #endregion

        #region misc

        public static void DrawIcon(Vector3 center, string name, bool allowScaling = true)
        {
            Gizmos.DrawIcon(center, name, allowScaling);
        }

        public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder = 0, int rightBorder = 0, int topBorder = 0, int bottomBorder = 0, Material mat = null)
        {
            Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat);
        }
        #endregion
    }

    /* public static class DebugExtension
    {
        #region DebugDrawFunctions

        public static void DebugPoint(Vector3 position, Color color, float scale = 1.0f, float duration = 0, bool depthTest = true)
        {
            color = color == default(Color) ? DefaultColor : color;

            Debug.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale, color, duration, depthTest);
            Debug.DrawRay(position + (Vector3.right * (scale * 0.5f)), -Vector3.right * scale, color, duration, depthTest);
            Debug.DrawRay(position + (Vector3.forward * (scale * 0.5f)), -Vector3.forward * scale, color, duration, depthTest);
        }

        public static void DebugPoint(Vector3 position, float scale = 1.0f, float duration = 0, bool depthTest = true)
        {
            DebugPoint(position, DefaultColor, scale, duration, depthTest);
        }

        public static void DebugBounds(Bounds bounds, Color color, float duration = 0, bool depthTest = true)
        {
            Vector3 center = bounds.center;

            float x = bounds.extents.x;
            float y = bounds.extents.y;
            float z = bounds.extents.z;

            Vector3 ruf = center + new Vector3(x, y, z);
            Vector3 rub = center + new Vector3(x, y, -z);
            Vector3 luf = center + new Vector3(-x, y, z);
            Vector3 lub = center + new Vector3(-x, y, -z);

            Vector3 rdf = center + new Vector3(x, -y, z);
            Vector3 rdb = center + new Vector3(x, -y, -z);
            Vector3 lfd = center + new Vector3(-x, -y, z);
            Vector3 lbd = center + new Vector3(-x, -y, -z);

            Debug.DrawLine(ruf, luf, color, duration, depthTest);
            Debug.DrawLine(ruf, rub, color, duration, depthTest);
            Debug.DrawLine(luf, lub, color, duration, depthTest);
            Debug.DrawLine(rub, lub, color, duration, depthTest);

            Debug.DrawLine(ruf, rdf, color, duration, depthTest);
            Debug.DrawLine(rub, rdb, color, duration, depthTest);
            Debug.DrawLine(luf, lfd, color, duration, depthTest);
            Debug.DrawLine(lub, lbd, color, duration, depthTest);

            Debug.DrawLine(rdf, lfd, color, duration, depthTest);
            Debug.DrawLine(rdf, rdb, color, duration, depthTest);
            Debug.DrawLine(lfd, lbd, color, duration, depthTest);
            Debug.DrawLine(lbd, rdb, color, duration, depthTest);
        }

        public static void DebugBounds(Bounds bounds, float duration = 0, bool depthTest = true)
        {
            DebugBounds(bounds, DefaultColor, duration, depthTest);
        }

        public static void DebugLocalCube(Transform transform, Vector3 size, Color color, Vector3 center = default(Vector3), float duration = 0, bool depthTest = true)
        {
            Vector3 lbb = transform.TransformPoint(center + ((-size) * 0.5f));
            Vector3 rbb = transform.TransformPoint(center + (new Vector3(size.x, -size.y, -size.z) * 0.5f));

            Vector3 lbf = transform.TransformPoint(center + (new Vector3(size.x, -size.y, size.z) * 0.5f));
            Vector3 rbf = transform.TransformPoint(center + (new Vector3(-size.x, -size.y, size.z) * 0.5f));

            Vector3 lub = transform.TransformPoint(center + (new Vector3(-size.x, size.y, -size.z) * 0.5f));
            Vector3 rub = transform.TransformPoint(center + (new Vector3(size.x, size.y, -size.z) * 0.5f));

            Vector3 luf = transform.TransformPoint(center + ((size) * 0.5f));
            Vector3 ruf = transform.TransformPoint(center + (new Vector3(-size.x, size.y, size.z) * 0.5f));

            Debug.DrawLine(lbb, rbb, color, duration, depthTest);
            Debug.DrawLine(rbb, lbf, color, duration, depthTest);
            Debug.DrawLine(lbf, rbf, color, duration, depthTest);
            Debug.DrawLine(rbf, lbb, color, duration, depthTest);

            Debug.DrawLine(lub, rub, color, duration, depthTest);
            Debug.DrawLine(rub, luf, color, duration, depthTest);
            Debug.DrawLine(luf, ruf, color, duration, depthTest);
            Debug.DrawLine(ruf, lub, color, duration, depthTest);

            Debug.DrawLine(lbb, lub, color, duration, depthTest);
            Debug.DrawLine(rbb, rub, color, duration, depthTest);
            Debug.DrawLine(lbf, luf, color, duration, depthTest);
            Debug.DrawLine(rbf, ruf, color, duration, depthTest);
        }

        public static void DebugLocalCube(Transform transform, Vector3 size, Vector3 center = default(Vector3), float duration = 0, bool depthTest = true)
        {
            DebugLocalCube(transform, size, DefaultColor, center, duration, depthTest);
        }

        public static void DebugLocalCube(Matrix4x4 space, Vector3 size, Color color, Vector3 center = default(Vector3), float duration = 0, bool depthTest = true)
        {
            color = (color == default(Color)) ? DefaultColor : color;

            Vector3 lbb = space.MultiplyPoint3x4(center + ((-size) * 0.5f));
            Vector3 rbb = space.MultiplyPoint3x4(center + (new Vector3(size.x, -size.y, -size.z) * 0.5f));

            Vector3 lbf = space.MultiplyPoint3x4(center + (new Vector3(size.x, -size.y, size.z) * 0.5f));
            Vector3 rbf = space.MultiplyPoint3x4(center + (new Vector3(-size.x, -size.y, size.z) * 0.5f));

            Vector3 lub = space.MultiplyPoint3x4(center + (new Vector3(-size.x, size.y, -size.z) * 0.5f));
            Vector3 rub = space.MultiplyPoint3x4(center + (new Vector3(size.x, size.y, -size.z) * 0.5f));

            Vector3 luf = space.MultiplyPoint3x4(center + ((size) * 0.5f));
            Vector3 ruf = space.MultiplyPoint3x4(center + (new Vector3(-size.x, size.y, size.z) * 0.5f));

            Debug.DrawLine(lbb, rbb, color, duration, depthTest);
            Debug.DrawLine(rbb, lbf, color, duration, depthTest);
            Debug.DrawLine(lbf, rbf, color, duration, depthTest);
            Debug.DrawLine(rbf, lbb, color, duration, depthTest);

            Debug.DrawLine(lub, rub, color, duration, depthTest);
            Debug.DrawLine(rub, luf, color, duration, depthTest);
            Debug.DrawLine(luf, ruf, color, duration, depthTest);
            Debug.DrawLine(ruf, lub, color, duration, depthTest);

            Debug.DrawLine(lbb, lub, color, duration, depthTest);
            Debug.DrawLine(rbb, rub, color, duration, depthTest);
            Debug.DrawLine(lbf, luf, color, duration, depthTest);
            Debug.DrawLine(rbf, ruf, color, duration, depthTest);
        }

        public static void DebugLocalCube(Matrix4x4 space, Vector3 size, Vector3 center = default(Vector3), float duration = 0, bool depthTest = true)
        {
            DebugLocalCube(space, size, DefaultColor, center, duration, depthTest);
        }

        public static void DebugCircle(Vector3 position, Vector3 up, Color color, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            Vector3 _up = up.normalized * radius;
            Vector3 _forward = Vector3.Slerp(_up, -_up, 0.5f);
            Vector3 _right = Vector3.Cross(_up, _forward).normalized * radius;

            Matrix4x4 matrix = new Matrix4x4();

            matrix[0] = _right.x;
            matrix[1] = _right.y;
            matrix[2] = _right.z;

            matrix[4] = _up.x;
            matrix[5] = _up.y;
            matrix[6] = _up.z;

            matrix[8] = _forward.x;
            matrix[9] = _forward.y;
            matrix[10] = _forward.z;

            Vector3 _lastPoint = position + matrix.MultiplyPoint3x4(new Vector3(Mathf.Cos(0), 0, Mathf.Sin(0)));
            Vector3 _nextPoint = Vector3.zero;

            color = (color == default(Color)) ? DefaultColor : color;

            for (var i = 0; i < 91; i++)
            {
                _nextPoint.x = Mathf.Cos((i * 4) * Mathf.Deg2Rad);
                _nextPoint.z = Mathf.Sin((i * 4) * Mathf.Deg2Rad);
                _nextPoint.y = 0;

                _nextPoint = position + matrix.MultiplyPoint3x4(_nextPoint);

                Debug.DrawLine(_lastPoint, _nextPoint, color, duration, depthTest);
                _lastPoint = _nextPoint;
            }
        }

        public static void DebugCircle(Vector3 position, Color color, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            DebugCircle(position, Vector3.up, color, radius, duration, depthTest);
        }

        public static void DebugCircle(Vector3 position, Vector3 up, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            DebugCircle(position, up, DefaultColor, radius, duration, depthTest);
        }

        public static void DebugCircle(Vector3 position, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            DebugCircle(position, Vector3.up, DefaultColor, radius, duration, depthTest);
        }

        public static void DebugWireSphere(Vector3 position, Color color, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            float angle = 10.0f;

            Vector3 x = new Vector3(position.x, position.y + radius * Mathf.Sin(0), position.z + radius * Mathf.Cos(0));
            Vector3 y = new Vector3(position.x + radius * Mathf.Cos(0), position.y, position.z + radius * Mathf.Sin(0));
            Vector3 z = new Vector3(position.x + radius * Mathf.Cos(0), position.y + radius * Mathf.Sin(0), position.z);

            Vector3 new_x;
            Vector3 new_y;
            Vector3 new_z;

            for (int i = 1; i < 37; i++)
            {

                new_x = new Vector3(position.x, position.y + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad), position.z + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad));
                new_y = new Vector3(position.x + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad), position.y, position.z + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad));
                new_z = new Vector3(position.x + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad), position.y + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad), position.z);

                Debug.DrawLine(x, new_x, color, duration, depthTest);
                Debug.DrawLine(y, new_y, color, duration, depthTest);
                Debug.DrawLine(z, new_z, color, duration, depthTest);

                x = new_x;
                y = new_y;
                z = new_z;
            }
        }

        public static void DebugWireSphere(Vector3 position, float radius = 1.0f, float duration = 0, bool depthTest = true)
        {
            DebugWireSphere(position, DefaultColor, radius, duration, depthTest);
        }

        public static void DebugCylinder(Vector3 start, Vector3 end, Color color, float radius = 1, float duration = 0, bool depthTest = true)
        {
            Vector3 up = (end - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

    //Radial circles
            DebugExtension.DebugCircle(start, up, color, radius, duration, depthTest);
            DebugExtension.DebugCircle(end, -up, color, radius, duration, depthTest);
            DebugExtension.DebugCircle((start + end) * 0.5f, up, color, radius, duration, depthTest);

    //Side lines
            Debug.DrawLine(start + right, end + right, color, duration, depthTest);
            Debug.DrawLine(start - right, end - right, color, duration, depthTest);

            Debug.DrawLine(start + forward, end + forward, color, duration, depthTest);
            Debug.DrawLine(start - forward, end - forward, color, duration, depthTest);

    //Start endcap
            Debug.DrawLine(start - right, start + right, color, duration, depthTest);
            Debug.DrawLine(start - forward, start + forward, color, duration, depthTest);

    //End endcap
            Debug.DrawLine(end - right, end + right, color, duration, depthTest);
            Debug.DrawLine(end - forward, end + forward, color, duration, depthTest);
        }

        public static void DebugCylinder(Vector3 start, Vector3 end, float radius = 1, float duration = 0, bool depthTest = true)
        {
            DebugCylinder(start, end, DefaultColor, radius, duration, depthTest);
        }

        public static void DebugCone(Vector3 position, Vector3 direction, Color color, float angle = 45, float duration = 0, bool depthTest = true)
        {
            float length = direction.magnitude;

            Vector3 _forward = direction;
            Vector3 _up = Vector3.Slerp(_forward, -_forward, 0.5f);
            Vector3 _right = Vector3.Cross(_forward, _up).normalized * length;

            direction = direction.normalized;

            Vector3 slerpedVector = Vector3.Slerp(_forward, _up, angle / 90.0f);

            float dist;
            var farPlane = new Plane(-direction, position + _forward);
            var distRay = new Ray(position, slerpedVector);

            farPlane.Raycast(distRay, out dist);

            Debug.DrawRay(position, slerpedVector.normalized * dist, color);
            Debug.DrawRay(position, Vector3.Slerp(_forward, -_up, angle / 90.0f).normalized * dist, color, duration, depthTest);
            Debug.DrawRay(position, Vector3.Slerp(_forward, _right, angle / 90.0f).normalized * dist, color, duration, depthTest);
            Debug.DrawRay(position, Vector3.Slerp(_forward, -_right, angle / 90.0f).normalized * dist, color, duration, depthTest);

            DebugExtension.DebugCircle(position + _forward, direction, color, (_forward - (slerpedVector.normalized * dist)).magnitude, duration, depthTest);
            DebugExtension.DebugCircle(position + (_forward * 0.5f), direction, color, ((_forward * 0.5f) - (slerpedVector.normalized * (dist * 0.5f))).magnitude, duration, depthTest);
        }

        public static void DebugCone(Vector3 position, Vector3 direction, float angle = 45, float duration = 0, bool depthTest = true)
        {
            DebugCone(position, direction, DefaultColor, angle, duration, depthTest);
        }

        public static void DebugCone(Vector3 position, Color color, float angle = 45, float duration = 0, bool depthTest = true)
        {
            DebugCone(position, Vector3.up, color, angle, duration, depthTest);
        }

        public static void DebugCone(Vector3 position, float angle = 45, float duration = 0, bool depthTest = true)
        {
            DebugCone(position, Vector3.up, DefaultColor, angle, duration, depthTest);
        }

        public static void DebugArrow(Vector3 position, Vector3 direction, Color color, float duration = 0, bool depthTest = true)
        {
            Debug.DrawRay(position, direction, color, duration, depthTest);
            DebugExtension.DebugCone(position + direction, -direction * 0.333f, color, 15, duration, depthTest);
        }

        public static void DebugArrow(Vector3 position, Vector3 direction, float duration = 0, bool depthTest = true)
        {
            DebugArrow(position, direction, DefaultColor, duration, depthTest);
        }

        public static void DebugCapsule(Vector3 start, Vector3 end, Color color, float radius = 1, float duration = 0, bool depthTest = true)
        {
            Vector3 up = (end - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

            float height = (start - end).magnitude;
            float sideLength = Mathf.Max(0, (height * 0.5f) - radius);
            Vector3 middle = (end + start) * 0.5f;

            start = middle + ((start - middle).normalized * sideLength);
            end = middle + ((end - middle).normalized * sideLength);

    //Radial circles
            DebugExtension.DebugCircle(start, up, color, radius, duration, depthTest);
            DebugExtension.DebugCircle(end, -up, color, radius, duration, depthTest);

    //Side lines
            Debug.DrawLine(start + right, end + right, color, duration, depthTest);
            Debug.DrawLine(start - right, end - right, color, duration, depthTest);

            Debug.DrawLine(start + forward, end + forward, color, duration, depthTest);
            Debug.DrawLine(start - forward, end - forward, color, duration, depthTest);

            for (int i = 1; i < 26; i++)
            {

    //Start endcap
                Debug.DrawLine(Vector3.Slerp(right, -up, i / 25.0f) + start, Vector3.Slerp(right, -up, (i - 1) / 25.0f) + start, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(-right, -up, i / 25.0f) + start, Vector3.Slerp(-right, -up, (i - 1) / 25.0f) + start, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(forward, -up, i / 25.0f) + start, Vector3.Slerp(forward, -up, (i - 1) / 25.0f) + start, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(-forward, -up, i / 25.0f) + start, Vector3.Slerp(-forward, -up, (i - 1) / 25.0f) + start, color, duration, depthTest);

    //End endcap
                Debug.DrawLine(Vector3.Slerp(right, up, i / 25.0f) + end, Vector3.Slerp(right, up, (i - 1) / 25.0f) + end, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(-right, up, i / 25.0f) + end, Vector3.Slerp(-right, up, (i - 1) / 25.0f) + end, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(forward, up, i / 25.0f) + end, Vector3.Slerp(forward, up, (i - 1) / 25.0f) + end, color, duration, depthTest);
                Debug.DrawLine(Vector3.Slerp(-forward, up, i / 25.0f) + end, Vector3.Slerp(-forward, up, (i - 1) / 25.0f) + end, color, duration, depthTest);
            }
        }

        public static void DebugCapsule(Vector3 start, Vector3 end, float radius = 1, float duration = 0, bool depthTest = true)
        {
            DebugCapsule(start, end, DefaultColor, radius, duration, depthTest);
        }

        #endregion 


        public static void DrawArrow(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            Debug.DrawRay(pos, direction, color);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180+arrowHeadAngle,0) * new Vector3(0,0,1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0,180-arrowHeadAngle,0) * new Vector3(0,0,1);
            Debug.DrawRay(pos + direction, right * arrowHeadLength, color);
            Debug.DrawRay(pos + direction, left * arrowHeadLength, color);
        }
        */
}