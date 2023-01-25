using System.Collections;
using Energy;
using Energy.Consumer;
using UnityEngine;

namespace Combat.Weapons
{
    public class TimerBulletRequester : MonoBehaviour
    {
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private float delayTime;
        [SerializeField] private EnergyConsumer energyConsumer;

        private bool _isActive;

        
        private void OsIsActiveChanged()
        {
            _isActive = energyConsumer.IsActive;

            if (_isActive)
            {
                StartCoroutine(ShootingRoutine());
            }
            else
            {
                StopAllCoroutines();
            }
        }

        private IEnumerator ShootingRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delayTime);
                bulletSpawner.SpawnBullet();
            }
            yield break;
        }
        
        private void OnEnable()
        {
            energyConsumer.IsActiveStateChangedEvent.AddListener(OsIsActiveChanged);
        }
        
        private void OnDisable()
        {
            energyConsumer.IsActiveStateChangedEvent.RemoveListener(OsIsActiveChanged);
        }
    }
}