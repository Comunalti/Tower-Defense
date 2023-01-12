using Combat.Enemies.EnemyTargets;
using Combat.Enemies.EnemyTargets.Touch;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.Attack
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetChooser enemyTargetChooser;
        
        [SerializeField] private float attackDamage;
        
        [SerializeField] private EnemyTarget currentTouchedEnemyTarget;
        
        public UnityEvent SuccessfulAttackEvent;
        public UnityEvent FailedAttackEvent;
        public void Attack()
        {
            if (currentTouchedEnemyTarget != null)
            {
                currentTouchedEnemyTarget.HealthController.RemoveHealth(attackDamage);
                SuccessfulAttackEvent.Invoke();
            }
            else
            {
                FailedAttackEvent.Invoke();
            }
        }

        private void OnChooseEnemyTargetChanged()
        {
            currentTouchedEnemyTarget = enemyTargetChooser.CurrentChooseEnemyTarget;
        }
        
        private void OnEnable()
        {
            enemyTargetChooser.ChooseEnemyTargetChangedEvent.AddListener(OnChooseEnemyTargetChanged);
        }
        private void OnDisable()
        {
            enemyTargetChooser.ChooseEnemyTargetChangedEvent.RemoveListener(OnChooseEnemyTargetChanged);
        }
    }
}