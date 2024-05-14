using UnityEngine;

namespace NebulaNexus.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance = null;

        public static T Instance { get { return instance; } }

        /// <summary>
        /// Generic Base Awake Call
        /// </summary>
        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T)this;
            else if (instance != this)
                Destroy(gameObject);
        }
    }
}
