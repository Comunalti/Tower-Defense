using UnityEngine;
using UnityEngine.Events;

namespace Miscellaneous
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]private float targetTime = 2;
        [SerializeField]private float currentTime = 0;
        
        [SerializeField]private bool isActive;
        [SerializeField]private bool isLooping;
        [SerializeField]private bool startOnStart;
        [SerializeField]private bool restartOnEnable;

        [SerializeField] private string key;

        public UnityEvent<string> EndTimerEvent;

        private void OnEnable()
        {
            if (restartOnEnable)
            {
                StartTimer();
            }
        }

        private void Start()
        {
            if (startOnStart)
            {
                StartTimer(currentTime);
            }
        }

        private void Update()
        {
            if (isActive && currentTime < targetTime)
            {
                currentTime += Time.deltaTime;

                if (currentTime >= targetTime)
                {
                    EndTimerEvent.Invoke(key);
                    
                    if (isLooping)
                    {
                        StartTimer(0);
                    }
                }
            }
        }


        public void StartTimer(float setCurrentTime = 0)
        {
            currentTime = setCurrentTime;
            isActive = true;
        }

        public void FreezeTimer()
        {
            isActive = false;
        }

        public void ResumeTimer()
        {
            isActive = true;
        }
    }
}