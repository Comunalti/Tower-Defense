using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;

        public UnityEvent DeathEvent;
        
        private void OnHealthControllerChanged()
        {
            if (healthController.CurrentHealth <= 0)
            {
                DeathEvent.Invoke();
            }
        }
        
        private void OnEnable()
        {
            healthController.HealthControllerChangedEvent.AddListener(OnHealthControllerChanged);
        }
        private void OnDisable()
        {
            healthController.HealthControllerChangedEvent.RemoveListener(OnHealthControllerChanged);
        }
    }
}