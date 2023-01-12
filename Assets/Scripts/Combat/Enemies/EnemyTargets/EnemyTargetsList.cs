using System;
using System.Collections.Generic;

namespace Combat.Enemies.EnemyTargets
{
    public static class EnemyTargetsList
    {
        public static readonly List<EnemyTarget> EnemyTargets = new List<EnemyTarget>();
        public static bool HasAnyTarget => EnemyTargets.Count != 0;

        public static event Action<EnemyTarget> EnemyTargetAddedEvent;
        public static event Action<EnemyTarget> EnemyTargetRemovedEvent;

        public static void Add(EnemyTarget enemyTarget)
        {
            if (!EnemyTargets.Contains(enemyTarget))
            {
                EnemyTargets.Add(enemyTarget);
                EnemyTargetAddedEvent?.Invoke(enemyTarget);
            }
        }
        public static void Remove(EnemyTarget enemyTarget)
        {
            if (EnemyTargets.Contains(enemyTarget))
            {
                EnemyTargets.Remove(enemyTarget);
                EnemyTargetRemovedEvent?.Invoke(enemyTarget);
            }
        }
    }
}