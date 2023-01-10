using Combat.Health;
using UnityEngine;

namespace Combat.Enemies.EnemyTargets
{
    public class EnemyTarget : MonoBehaviour
    {
        // this class stays in the player things
        [field: SerializeField]public HealthController HealthController { get; }
        [field: SerializeField]public Transform Pivot { get; }
        // todo add more references to use in other scripts

        private void Awake()
        {
            EnemyTargetSelector.EnemyTargets.Add(this);
        }
    }
}