using Unity.VisualScripting;
using UnityEngine;

namespace SingletonPattern
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {   
                    _instance = (T)FindFirstObjectByType(typeof(T));
                    if (_instance == null)
                    {
                        Debug.LogError("Missing Singleton Instance");
                    }
                }
                return _instance;
            }
        }
        public virtual void Awake()
        {
            // Remove Duplicates
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}