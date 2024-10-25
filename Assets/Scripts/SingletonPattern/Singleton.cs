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
            Debug.Log(this.gameObject.name + " is Awake");
            // Remove Duplicates
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Debug.Log("Destroyed Duplicate" + this.gameObject.name);
                Debug.Log(_instance.gameObject.name);
                //Destroy(gameObject);
            }
        }
    }
}