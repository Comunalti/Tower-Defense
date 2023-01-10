using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies
{
    public class EnemyAttackHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetChooser enemyTargetToucher;

        
        [SerializeField] private float attackDamage;
        
        private EnemyTarget currentTouchedEnemyTarget;
        
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
            currentTouchedEnemyTarget = enemyTargetToucher.CurrentChooseEnemyTarget;
        }
        
        private void OnEnable()
        {
            enemyTargetToucher.ChooseEnemyTargetChangedEvent.AddListener(OnChooseEnemyTargetChanged);
        }
        private void OnDisable()
        {
            enemyTargetToucher.ChooseEnemyTargetChangedEvent.RemoveListener(OnChooseEnemyTargetChanged);
        }
    }
}