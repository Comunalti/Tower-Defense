using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.States
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState currentState;
        [SerializeField] private EnemyState initialState;
        
        public UnityEvent StateChangedEvent;

        public void SetCurrentState(EnemyState enemyState)
        {
            if (currentState != null)
            {
                currentState.LeaveState();
            }
            
            var changed = currentState == enemyState;
            currentState = enemyState;
            
            if (currentState != null)
            {
                currentState.EnterState();
            }

            if (changed)
            {
                StateChangedEvent.Invoke();
            }
        }
        
        
    }
}