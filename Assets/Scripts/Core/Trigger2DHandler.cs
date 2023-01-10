﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Enemies
{
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
}