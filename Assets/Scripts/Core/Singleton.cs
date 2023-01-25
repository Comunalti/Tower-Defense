using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T: Singleton<T>
    {
        private static T instance;
        public static T Instance
        {
            get {
                if (instance is null)
                {
                    Debug.LogError($"no single found, of type:{typeof(T).FullName}");
                }

                return instance; }
        }
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Only one instance, ignoring this instance",gameObject);
                return;
            }
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
            OnAwake();
        }


        protected virtual void OnAwake(){}
    }
}