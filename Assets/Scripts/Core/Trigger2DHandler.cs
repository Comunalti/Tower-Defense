using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
    public abstract class Trigger2DHandler<T> : MonoBehaviour
    {
        [SerializeField] private List<T> targetsTouched;
        public UnityEvent<T> targetAddedEvent;
        public UnityEvent<T> targetRemovedEvent;

        [field: SerializeField] public bool IsTouching { get; private set; }

        private void Refresh()
        {
            IsTouching = targetsTouched.Count != 0;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponentInChildren<T>();
            if (target!=null)
            {
                targetsTouched.Add(target);
                targetAddedEvent.Invoke(target);
                Refresh();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var target = other.GetComponentInChildren<T>();
            if (target!=null)
            {
                targetsTouched.Remove(target);
                targetRemovedEvent.Invoke(target);
                Refresh();
            }
        }
    }
}