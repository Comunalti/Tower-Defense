using UnityEngine;
using UnityEngine.Events;

namespace Energy
{
    public class EnergyStorage : MonoBehaviour
    {
        [SerializeField] private float currentEnergy;
        [SerializeField] private float maxEnergy;

        public float MaxEnergy => maxEnergy;
        public float CurrentEnergy => currentEnergy;

        public UnityEvent EnergyQuantityChangedEvent;

        public float AddEnergy(float value)
        {
            var beforeEnergy = currentEnergy;
            currentEnergy = Mathf.Clamp(currentEnergy+value, 0, maxEnergy);
            var added = currentEnergy - beforeEnergy;
            var rest = value - added;
            
            EnergyQuantityChangedEvent.Invoke();

            return rest;
        }
        public void RemoveEnergy(float value){
            currentEnergy = Mathf.Clamp(currentEnergy-value, 0, maxEnergy);
            EnergyQuantityChangedEvent.Invoke();

        }
        public void SetEnergy(float value){
            currentEnergy = Mathf.Clamp(value, 0, maxEnergy);
            EnergyQuantityChangedEvent.Invoke();
        }
    }
}