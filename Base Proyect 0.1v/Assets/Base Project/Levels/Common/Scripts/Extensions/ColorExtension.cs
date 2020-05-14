using UnityEngine;
using System.Collections;

namespace Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Change the alpha channel of the color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Color Alpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }
    }
}