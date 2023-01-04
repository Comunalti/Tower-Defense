using System;
using UnityEngine;
using UnityEngine.Events;

namespace Energy
{
    public class EnergyGenerator : MonoBehaviour
    {
        [SerializeField] private EnergyStorage energyStorage;

        [SerializeField]
        private float generationSpeed = 0;

        public UnityEvent GenerationSpeedChangedEvent;
        
        private void Update()
        {
         energyStorage.AddEnergy(generationSpeed*Time.deltaTime);
        }
        
    }
}