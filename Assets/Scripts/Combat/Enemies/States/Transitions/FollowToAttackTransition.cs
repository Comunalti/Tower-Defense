using System;
using Combat.Enemies.EnemyTargets;
using Combat.Enemies.EnemyTargets.Touch;
using UnityEngine;

namespace Combat.Enemies.States.Transitions
{
    public class FollowToAttackTransition : MonoBehaviour
    {
        [SerializeField] private EnemyTargetChooser enemyTargetChooser;
        [SerializeField] private EnemyStateMachine enemyStateMachine;
        [SerializeField] private EnemyState followState;
        [SerializeField] private EnemyState attackState;
        
        [SerializeField] private bool hasChoose;

        private void OnEnable()
        {
            enemyTargetChooser.ChooseEnemyTargetChangedEvent.AddListener(OnChooseEnemyTargetChanged);
        }

        private void OnDisable()
        {
            enemyTargetChooser.ChooseEnemyTargetChangedEvent.RemoveListener(OnChooseEnemyTargetChanged);
        }
        private void OnChooseEnemyTargetChanged()
        {
            hasChoose = enemyTargetChooser.HasChoose;

            if (hasChoose)
            {
                enemyStateMachine.SetCurrentState(attackState);
            }
            else
            {
                enemyStateMachine.SetCurrentState(followState);
            }
        }
    }
}