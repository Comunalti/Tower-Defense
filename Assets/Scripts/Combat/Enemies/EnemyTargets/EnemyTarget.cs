using System;
using Combat.Health;
using UnityEngine;

namespace Combat.Enemies.EnemyTargets
{
    [RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
    public class EnemyTarget : MonoBehaviour
    {
        // this class stays in the player things
        [field: SerializeField] public HealthController HealthController { get; private set; }
        [field: SerializeField] public Transform Pivot { get; private set; }
        // todo add more references to use in other scripts

        private void OnEnable()
        {
            EnemyTargetsList.Add(this);
        }

        private void OnDisable()
        {
            EnemyTargetsList.Remove(this);
        }
    }
}