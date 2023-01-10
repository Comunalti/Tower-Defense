using UnityEngine;
using UnityEngine.Events;

namespace Combat.Weapons
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform pivot;
        
        public UnityEvent bulletSpawnedEvent;

        public void SpawnBullet()
        {
            var clone = Instantiate(bulletPrefab,pivot.position,pivot.rotation);
            bulletSpawnedEvent.Invoke();
        }
    }
}