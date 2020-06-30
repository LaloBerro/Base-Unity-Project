using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// Perform an action if a component exists, skip otherwise
        /// </summary>
        /// <typeparam name="T">The type of component required</typeparam>
        /// <param name="self"></param>
        /// <param name="callback">The action to take</param>
        /// <returns>The component found</returns>
        public static T GetComponent<T>(this GameObject self, System.Action<T> callback) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                callback.Invoke(component);
            }

            return component;
        }

        /// <summary>
        /// Get a component, take a different action if it isn't there
        /// </summary>
        /// <typeparam name="T">Component Type</typeparam>
        /// <param name="self">object being extended</param>
        /// <param name="success">Take this action if the component exists</param>
        /// <param name="failure">Take this action if the component does not exist</param>
        /// <returns></returns>
        public static T GetComponent<T>(this GameObject self, System.Action<T> success, System.Action failure) where T : Component
        {
            var component = self.GetComponent<T>();

            if (component != null)
            {
                success.Invoke(component);
                return component;
            }
            else
            {
                failure.Invoke();
                return null;
            }
        }
    }
}