using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.EnemyTargets
{
    /// <summary>
    /// a class that Selects the closest EnemyTarget from the enemy that the pivot is in, this shall stay inside each enemy.
    /// has a event that updates whenever the CurrentEnemyTarget changes.
    /// </summary>
    public class EnemyTargetSelector : MonoBehaviour
    {
        public static readonly List<EnemyTarget> EnemyTargets = new List<EnemyTarget>();

        [SerializeField] private Transform pivot;
        
        public EnemyTarget CurrentEnemyTarget { get; private set; }

        public UnityEvent EnemyTargetChangedEvent;
        
        private void Update()
        {
            var lastFrameCurrentEnemyTarget = CurrentEnemyTarget;
            CurrentEnemyTarget = GetClosestEnemyTarget(pivot.position);
            
            if (lastFrameCurrentEnemyTarget != CurrentEnemyTarget)
            {
                EnemyTargetChangedEvent.Invoke();
            }
        }
        
        public static EnemyTarget GetClosestEnemyTarget(Vector2 position)
        {
            var closestDistance = Mathf.Infinity;
            EnemyTarget closestEnemyTarget = null;
            
            foreach (var enemyTarget in EnemyTargets)
            {
                var distance = Vector2.Distance(enemyTarget.Pivot.position,position);
                if (distance<=closestDistance)
                {
                    closestDistance = distance;
                    closestEnemyTarget = enemyTarget;
                }
            }

            return closestEnemyTarget;
        }
    }
}