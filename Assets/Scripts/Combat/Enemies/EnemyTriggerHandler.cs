using System;
using UnityEngine;

namespace Combat.Enemies
{
    public class EnemyTriggerHandler : MonoBehaviour
    {
        // trigger in a layer (EnemyTargetLayer) when enemy gets inside the area, trigger alerts

        public enum TriggerType
        {
            enemy,
            player,
            other,
        }

        [SerializeField] private TriggerType triggerType;

        private void OnTriggerEnter2D(Collider2D col)
        {
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
        }
    }
    
}