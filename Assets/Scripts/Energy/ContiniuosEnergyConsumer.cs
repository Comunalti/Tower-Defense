using System;
using UnityEngine;
using UnityEngine.Events;

namespace Energy
{
    public abstract class EnergyConsumer : MonoBehaviour
    {
        public UnityEvent IsActiveStateChangedEvent;
        [field: SerializeField] public bool IsActive { get; protected set; }
    }
    public class ContinuousEnergyConsumer : EnergyConsumer
    {
        //todo: create discrete version
        
        [SerializeField] private EnergyStorage energyStorage;
        [SerializeField] [Tooltip("Per Sec")] private float energyCost;

        public UnityEvent IsActiveStateChangedEvent;
        
        
        private void Update()
        {
            var wasOnLastFrame = IsActive;
            
            if (energyStorage.CurrentEnergy >= energyCost)
            {
                energyStorage.RemoveEnergy(energyCost);
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