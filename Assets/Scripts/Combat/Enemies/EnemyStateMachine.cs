using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies
{

    public class DeathController : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;

        public UnityEvent DeathEvent;
        
        private void OnHealthControllerChanged()
        {
            if (healthController.CurrentHealth <= 0)
            {
                DeathEvent.Invoke();
            }
        }
        
        private void OnEnable()
        {
            healthController.HealthControllerChangedEvent.AddListener(OnHealthControllerChanged);
        }
        private void OnDisable()
        {
            healthController.HealthControllerChangedEvent.RemoveListener(OnHealthControllerChanged);
        }
    }
    
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth;

        public float CurrentHealth => currentHealth;

        public float MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = value;
                HealthControllerChangedEvent.Invoke();
            }
        }

        public UnityEvent HealthControllerChangedEvent;
        public void RemoveHealth(float value)
        {
            currentHealth = Mathf.Clamp(currentHealth - value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
        
        public void AddHealth(float value)
        {
            currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
        
        public void SetHealth(float value)
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            HealthControllerChangedEvent.Invoke();
        }
    }
    
    
    /// <summary>
    /// a class that Selects the closest EnemyTarget from the enemy that the pivot is in, this shall stay inside each enemy.
    /// has a event that updates whenever the CurrentEnemyTarget changes.
    /// </summary>
    public class EnemyTargetSelector : MonoBehaviour
    {
        public static readonly List<EnemyTarget> EnemyTargets = new List<EnemyTarget>();

        [SerializeField] private Transform pivot;
        
        public EnemyTarget CurrentEnemyTarget { get; private set; }

        public UnityEvent EnemyTargetChangedEvent;
        
        private void Update()
        {
            var lastFrameCurrentEnemyTarget = CurrentEnemyTarget;
            CurrentEnemyTarget = GetClosestEnemyTarget(pivot.position);
            
            if (lastFrameCurrentEnemyTarget != CurrentEnemyTarget)
            {
                EnemyTargetChangedEvent.Invoke();
            }
        }
        
        public static EnemyTarget GetClosestEnemyTarget(Vector2 position)
        {
            var closestDistance = Mathf.Infinity;
            EnemyTarget closestEnemyTarget = null;
            
            foreach (var enemyTarget in EnemyTargets)
            {
                var distance = Vector2.Distance(enemyTarget.Pivot.position,position);
                if (distance<=closestDistance)
                {
                    closestDistance = distance;
                    closestEnemyTarget = enemyTarget;
                }
            }

            return closestEnemyTarget;
        }
    }
    public class EnemyTarget : MonoBehaviour
    {
        // this class stays in the player things
        [field: SerializeField]public HealthController HealthController { get; }
        [field: SerializeField]public Transform Pivot { get; }
        // todo add more references to use in other scripts

        private void Awake()
        {
            EnemyTargetSelector.EnemyTargets.Add(this);
        }
    }

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

    public abstract class Trigger2DHandler<T> : MonoBehaviour
    {
        [SerializeField] private List<T> targetsTouched;
        public UnityEvent<T> targetAddedEvent;
        public UnityEvent<T> targetRemovedEvent;
            
        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponentInChildren<T>();
            if (target!=null)
            {
                targetsTouched.Add(target);
                targetAddedEvent.Invoke(target);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var target = other.GetComponentInChildren<T>();
            if (target!=null)
            {
                targetsTouched.Remove(target);
                targetRemovedEvent.Invoke(target);
            }
        }
    }

    public class EnemyTargetTouchTrigger : Trigger2DHandler<EnemyTarget>
    {
        // public class EnemyTargetToucher : MonoBehaviour
        // {
        //     [SerializeField] private List<EnemyTarget> enemyTargetsTouched;
        //     public UnityEvent<EnemyTarget> EnemyTargetAddedEvent;
        //     public UnityEvent<EnemyTarget> EnemyTargetRemovedEvent;
        //         
        //     private void OnTriggerEnter2D(Collider2D other)
        //     {
        //         var enemyTarget = other.GetComponentInChildren<EnemyTarget>();
        //         if (enemyTarget!=null)
        //         {
        //             enemyTargetsTouched.Add(enemyTarget);
        //             EnemyTargetAddedEvent.Invoke(enemyTarget);
        //         }
        //     }
        //
        //     private void OnTriggerExit2D(Collider2D other)
        //     {
        //         var enemyTarget = other.GetComponentInChildren<EnemyTarget>();
        //         if (enemyTarget!=null)
        //         {
        //             enemyTargetsTouched.Remove(enemyTarget);
        //             EnemyTargetRemovedEvent.Invoke(enemyTarget);
        //         }
        //     }
        // }
    }
    
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
    

    public class EnemyAttackDelayController : MonoBehaviour
    {
        [SerializeField] private EnemyState attackState;
        [SerializeField] private EnemyAttackHandler enemyAttackHandler;

        [SerializeField] private float delayTime;
        
        
        private bool _isActive;


        IEnumerator AttackingRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delayTime);
                enemyAttackHandler.Attack();
            }
            yield break;
        }
        
        
        private void OnEnterState()
        {
            _isActive = true;
            StartCoroutine(AttackingRoutine());
        }
        private void OnLeaveState()
        {
            _isActive = false;
            StopAllCoroutines();
        }
        
        private void OnEnable()
        {
            attackState.EnterStateEvent.AddListener(OnEnterState);
            attackState.EnterStateEvent.AddListener(OnLeaveState);
        }

        
        private void OnDisable()
        {
            attackState.EnterStateEvent.RemoveListener(OnEnterState);
            attackState.EnterStateEvent.RemoveListener(OnLeaveState);

        }
    }
    
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