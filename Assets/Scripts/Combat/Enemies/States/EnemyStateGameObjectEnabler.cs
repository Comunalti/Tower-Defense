using UnityEngine;

namespace Combat.Enemies.States
{
    public class EnemyStateGameObjectEnabler : MonoBehaviour
    {
        [SerializeField] private EnemyState enemyState;
        [SerializeField] private GameObject gameObject;
        private void OnEnable()
        {
            enemyState.EnterStateEvent.AddListener(OnEnterState);
            enemyState.LeaveStateEvent.AddListener(OnLeaveState);
        }
        
        private void OnDisable()
        {
            enemyState.EnterStateEvent.RemoveListener(OnEnterState);
            enemyState.LeaveStateEvent.RemoveListener(OnLeaveState);
        }

        private void OnLeaveState()
        {
            gameObject.SetActive(false);
        }

        private void OnEnterState()
        {
            gameObject.SetActive(true);
        }
    }
}