using UnityEngine;

namespace GDC.Utilities
{
    /// <summary>
    /// Singleton base behaviour.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        #region MonoBehaviour methods
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }
        #endregion



        #region Private methods

        #endregion
    }
}
