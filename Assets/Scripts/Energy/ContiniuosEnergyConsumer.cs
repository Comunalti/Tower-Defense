using System;
using UnityEngine;
using UnityEngine.Events;

namespace Energy
{
    public class ContinuousEnergyConsumer : MonoBehaviour
    {
        //todo: create discrete version and interface
        
        [SerializeField] private EnergyStorage energyStorage;
        [SerializeField] [Tooltip("Per Sec")] private float energyCost;
        [SerializeField] private bool isActive;

        public bool IsActive => isActive;
        public UnityEvent IsActiveStateChangedEvent;
        
        
        private void Update()
        {
            var wasOnLastFrame = isActive;
            
            if (energyStorage.CurrentEnergy >= energyCost)
            {
                energyStorage.RemoveEnergy(energyCost);
                isActive = true;
            }
            else
            {
                isActive = false;
            }
            
            if (isActive!=wasOnLastFrame)
            {
                IsActiveStateChangedEvent.Invoke();
            }
        }
    }
}