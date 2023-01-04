using System;
using Connections;
using UnityEngine;

namespace Energy
{
    public class ContinuousEnergySender : MonoBehaviour
    {
        [SerializeField] private ConnectionHandler connectionHandler;
        [SerializeField] private EnergyStorage energyStorageFrom;
        [SerializeField] private EnergyStorage energyStorageTo;
        [SerializeField] [Tooltip("Per Sec")]private float quantity;

        private void Awake()
        {
            if (energyStorageFrom is null)
            {
                Debug.LogWarning("no energyStorage defined in prefab",gameObject);
            }
        }

        private void OnConnectionChanged()
        {
            if (connectionHandler.ConnectedHandler is null)
            {
                energyStorageTo = null;
                return;
            }
            //todo: continuar
            //energyStorageTo = connectionHandler.ConnectedHandler.GetComponentInChildren<EnergyStorage>();
        }
        
        private void Update()
        {
            if (energyStorageFrom is null || energyStorageTo is null)
            {
                return;
            }
            var energy = Mathf.Clamp(energyStorageFrom.CurrentEnergy, 0, quantity * Time.deltaTime);
            
            var rest = energyStorageTo.AddEnergy(energy);
            energyStorageFrom.RemoveEnergy(energy-rest);
        }

        private void OnEnable()
        {
            connectionHandler.ConnectionChangedEvent.AddListener(OnConnectionChanged);
        }

        private void OnDisable()
        {
            connectionHandler.ConnectionChangedEvent.RemoveListener(OnConnectionChanged);
        }
    }
}