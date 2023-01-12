using System;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.States
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState currentState;
        [SerializeField] private EnemyState initialState;
        
        public UnityEvent StateChangedEvent;

        private void Start()
        {
            SetCurrentState(initialState);
        }

        public void SetCurrentState(EnemyState enemyState)
        {
            var a = currentState ? currentState.name : "null";
            var b = enemyState ? enemyState.name : "null";
            print($"changing state, from: {a} to: {b}");
            
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