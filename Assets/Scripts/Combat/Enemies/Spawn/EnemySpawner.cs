using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform pivot;
        
        public UnityEvent enemySpawnedEvent;

        public void SpawnEnemy()
        {
            var clone = Instantiate(enemyPrefab,pivot.position,pivot.rotation);
            enemySpawnedEvent.Invoke();
        }
    }
}