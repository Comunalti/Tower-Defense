using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.EnemyTargets.Touch
{
    public class EnemyTargetChooser : MonoBehaviour
    {
        [SerializeField] private EnemyTargetTouchTrigger enemyTargetTouchTrigger;
        
        [SerializeField] private EnemyTarget currentChooseEnemyTarget;
        
        public EnemyTarget CurrentChooseEnemyTarget => currentChooseEnemyTarget;

        public UnityEvent ChooseEnemyTargetChangedEvent;
        private void OnTargetAdded(EnemyTarget enemyTarget)
        {
            currentChooseEnemyTarget = enemyTarget;
        }
        
        private void OnEnable()
        {
            enemyTargetTouchTrigger.targetAddedEvent.AddListener(OnTargetAdded);
        }

        private void OnDisable()
        {
            enemyTargetTouchTrigger.targetAddedEvent.RemoveListener(OnTargetAdded);
        }
    }
}