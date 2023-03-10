using System;
using Combat.Enemies.EnemyTargets;
using UnityEngine;

namespace Combat.Enemies.States.Transitions
{
    public class IdleTransition : MonoBehaviour
    {

        [SerializeField] private EnemyStateMachine enemyStateMachine;
        [SerializeField] private EnemyState enemyState;

        // private void Update()
        // {
        //     Refresh();
        // }

        private void Refresh(EnemyTarget enemyTarget = null)
        {
            if (!EnemyTargetsList.HasAnyTarget)
            {
                enemyStateMachine.SetCurrentState(enemyState);
            }
            else
            {
                
            }
        }
        
        private void OnEnable()
        {
            EnemyTargetsList.EnemyTargetRemovedEvent += Refresh;
        }
        
        private void OnDisable()
        {
            EnemyTargetsList.EnemyTargetRemovedEvent -= Refresh;
        }
    }
}