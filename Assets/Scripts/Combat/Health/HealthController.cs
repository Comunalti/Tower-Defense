using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth;

        public float CurrentHealth => currentHealth;

        public float MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = value;
                HealthControllerChangedEvent.Invoke();
            }
        }

        public UnityEvent HealthControllerChangedEvent;
        public void RemoveHealth(float value)
        {
            currentHealth = Mathf.Clamp(currentHealth - value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
        
        public void AddHealth(float value)
        {
            currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
        
        public void SetHealth(float value)
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
    }
}