using System;
using UnityEngine;

namespace Energy.Generator
{
    public class ContinuousEnergyGeneration : MonoBehaviour
    {
        [SerializeField] private EnergyStorage energyStorage;
        [SerializeField] private float quantity;
        private void Update()
        {
            energyStorage.AddEnergy(quantity*Time.deltaTime);
        }
    }
}