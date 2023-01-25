using System;
using Connections;
using Connections.ConnectionSystem.Cable;
using UnityEngine;

namespace Energy.Cable
{
    public class CableEnergyTransferCable : MonoBehaviour
    {
        [SerializeField] private CableConnectionHandler male;
        [SerializeField] private CableConnectionHandler female;
        private EnergyStorage femaleEnergyStorage;
        private EnergyStorage maleEnergyStorage;

        [SerializeField] private float quantity;
        private bool isActive;

        private void Update()
        {
            isActive = femaleEnergyStorage != null && maleEnergyStorage != null;

            if (isActive)
            {
                var energy = Mathf.Clamp(femaleEnergyStorage.CurrentEnergy, 0, quantity * Time.deltaTime);
            
                var rest = maleEnergyStorage.AddEnergy(energy);
                femaleEnergyStorage.RemoveEnergy(energy-rest);
            }
        }
        
        private void OnEnable()
        {
            male.ConnectionChangedEvent.AddListener(OnMaleChanged);
            female.ConnectionChangedEvent.AddListener(OnFemaleChanged);
        }
        private void OnDisable()
        {
            male.ConnectionChangedEvent.RemoveListener(OnMaleChanged);
            female.ConnectionChangedEvent.RemoveListener(OnFemaleChanged);
        }
        private void OnFemaleChanged()
        {
            femaleEnergyStorage = female.currentBaseConnectedHandler?female.currentBaseConnectedHandler.BaseNodeConnector.energyStorage : null;
        }

        private void OnMaleChanged()
        {
            maleEnergyStorage = male.currentBaseConnectedHandler?male.currentBaseConnectedHandler.BaseNodeConnector.energyStorage : null;
        }

        
    }
}