using System.Collections;
using Combat.Enemies.States;
using UnityEngine;

namespace Combat.Enemies.Attack
{
    public class EnemyAttackDelayController : MonoBehaviour
    {
        [SerializeField] private EnemyState attackState;
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
        
        
        private void OnEnterState()
        {
            _isActive = true;
            StartCoroutine(AttackingRoutine());
        }
        private void OnLeaveState()
        {
            _isActive = false;
            StopAllCoroutines();
        }
        
        private void OnEnable()
        {
            attackState.EnterStateEvent.AddListener(OnEnterState);
            attackState.EnterStateEvent.AddListener(OnLeaveState);
        }

        
        private void OnDisable()
        {
            attackState.EnterStateEvent.RemoveListener(OnEnterState);
            attackState.EnterStateEvent.RemoveListener(OnLeaveState);

        }
    }
}