using UnityEngine;
using UnityEngine.Events;

namespace Energy.Consumer
{
    public class ContinuousEnergyConsumer : EnergyConsumer
    {
        //todo: create discrete version
        
        [SerializeField] private EnergyStorage energyStorage;
        [SerializeField] [Tooltip("Per Sec")] private float energyCost;
        
        private void Update()
        {
            var wasOnLastFrame = IsActive;
            
            if (energyStorage.CurrentEnergy >= energyCost)
            {
                energyStorage.RemoveEnergy(energyCost*Time.deltaTime);
                IsActive = true;
            }
            else
            {
                IsActive = false;
            }
            
            if (IsActive!=wasOnLastFrame)
            {
                IsActiveStateChangedEvent.Invoke();
            }
        }
    }
}