using System;
using Combat.Enemies.EnemyTargets;
using UnityEngine;

namespace Combat.Enemies.Mover
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private EnemyTarget currentEnemyTarget;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;
        [SerializeField] private EnemyTargetSelector enemyTargetSelector;
        private void FixedUpdate()
        {
            if (currentEnemyTarget == null)
            {
                return;
            }
            var destination = (Vector2)currentEnemyTarget.Pivot.position;
            var origin = rigidbody2D.position;
            var direction = ( destination - origin).normalized;
            rigidbody2D.MovePosition(  origin + direction * (speed * Time.fixedDeltaTime));
        }

        private void OnEnable()
        {
            enemyTargetSelector.EnemyTargetChangedEvent.AddListener(OnEnemyTargetChanged);
        }
        
        private void OnDisable()
        {
            enemyTargetSelector.EnemyTargetChangedEvent.RemoveListener(OnEnemyTargetChanged);
        }

        private void OnEnemyTargetChanged()
        {
            currentEnemyTarget = enemyTargetSelector.CurrentEnemyTarget;
        }
    }
}