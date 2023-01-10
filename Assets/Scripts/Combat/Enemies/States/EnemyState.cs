using System;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies.States
{
    public class EnemyState : MonoBehaviour
    {
        [field: SerializeField] public String Name { get;}

        public UnityEvent EnterStateEvent;
        public UnityEvent LeaveStateEvent;
        
        public virtual void EnterState()
        {
            EnterStateEvent.Invoke();
        }
        
        public virtual void LeaveState()
        {
            LeaveStateEvent.Invoke();
        }
    }
}