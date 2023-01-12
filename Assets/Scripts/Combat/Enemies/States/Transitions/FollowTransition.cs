using Combat.Enemies.EnemyTargets;
using UnityEngine;

namespace Combat.Enemies.States.Transitions
{
    public class FollowTransition : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine enemyStateMachine;
        [SerializeField] private EnemyState enemyState;
        // private void Update()
        // {
        //     Refresh();
        // }

        private void Refresh(EnemyTarget enemyTarget = null)
        {
            if (EnemyTargetsList.HasAnyTarget)
            {
                enemyStateMachine.SetCurrentState(enemyState);
            }
        }
        
        private void OnEnable()
        {
            EnemyTargetsList.EnemyTargetAddedEvent += Refresh;
        }
        
        private void OnDisable()
        {
            EnemyTargetsList.EnemyTargetAddedEvent -= Refresh;
        }
    }
}