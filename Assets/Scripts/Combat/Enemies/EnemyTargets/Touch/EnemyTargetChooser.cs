using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.EnemyTargets.Touch
{
    public class EnemyTargetChooser : MonoBehaviour
    {
        [SerializeField] private EnemyTargetTouchTrigger enemyTargetTouchTrigger;
        
        [SerializeField] private EnemyTarget currentChooseEnemyTarget;
        
        public EnemyTarget CurrentChooseEnemyTarget => currentChooseEnemyTarget;

        public bool HasChoose => currentChooseEnemyTarget != null;
        
        public UnityEvent ChooseEnemyTargetChangedEvent;
        private void OnTargetAdded(EnemyTarget enemyTarget)
        {
            currentChooseEnemyTarget = enemyTarget;
            ChooseEnemyTargetChangedEvent.Invoke();
        }
        private void OnTargetRemoved(EnemyTarget enemyTarget)
        {
            if (currentChooseEnemyTarget == enemyTarget)
            {
                currentChooseEnemyTarget = null;
                ChooseEnemyTargetChangedEvent.Invoke();
            }
        }
        
        private void OnEnable()
        {
            enemyTargetTouchTrigger.targetAddedEvent.AddListener(OnTargetAdded);
            enemyTargetTouchTrigger.targetRemovedEvent.AddListener(OnTargetRemoved);
        }

        private void OnDisable()
        {
            enemyTargetTouchTrigger.targetAddedEvent.RemoveListener(OnTargetAdded);
            enemyTargetTouchTrigger.targetRemovedEvent.RemoveListener(OnTargetRemoved);

        }
    }
}