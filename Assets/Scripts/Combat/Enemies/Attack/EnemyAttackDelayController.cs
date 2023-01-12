using System;
using System.Collections;
using UnityEngine;

namespace Combat.Enemies.Attack
{
    public class EnemyAttackDelayController : MonoBehaviour
    {
        [SerializeField] private EnemyAttackHandler enemyAttackHandler;

        [SerializeField] private float delayTime;

        private bool _isActive;
        
        IEnumerator AttackingRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delayTime);
                enemyAttackHandler.Attack();
            }
            yield break;
        }
        
        private void OnEnable()
        {
            _isActive = true; 
            StartCoroutine(AttackingRoutine());
        }

        
        private void OnDisable()
        {
          _isActive = false;
          StopAllCoroutines();
        }
    }
}