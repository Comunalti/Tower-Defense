using System;
using Energy.Consumer;
using UnityEngine;

namespace Energy.Actuators
{
    public class DebugEnergyActuator : MonoBehaviour
    {
        // todo: make this work with the interface of energyConsumer
        [SerializeField] private ContinuousEnergyConsumer continuousEnergyConsumer;

        private bool _isActive; 
        
        
        private void OnIsActiveStateChanged()
        {
            _isActive = continuousEnergyConsumer.IsActive;
            print($"is active state is: {_isActive}");
        }

        private void OnEnable()
        {
            continuousEnergyConsumer.IsActiveStateChangedEvent.AddListener(OnIsActiveStateChanged);
        }

        private void OnDisable()
        {
            continuousEnergyConsumer.IsActiveStateChangedEvent.RemoveListener(OnIsActiveStateChanged);
        }
    }
}