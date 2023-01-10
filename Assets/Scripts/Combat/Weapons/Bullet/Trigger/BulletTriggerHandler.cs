using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Bullet.Trigger
{
    public class BulletTriggerHandler : MonoBehaviour
    {

        public UnityEvent BulletHitEnemyEvent;
        //public UnityEvent BulletHitWallEvent;
        //public String wallTag;
        private void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.GetComponent<EnemyBulletTrigger>();
            if (col != null)
            {
                BulletHitEnemyEvent.Invoke();
            }

            // if (col.CompareTag(wallTag))
            // {
            //     
            // }
        }
    }
}