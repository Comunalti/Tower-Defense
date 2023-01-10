using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T: Singleton<T>
    {
        public static T Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("Only one instance, ignoring this instance",gameObject);
                return;
            }
            Instance = (T)this;
            OnAwake();
        }


        protected virtual void OnAwake(){}
    }
}