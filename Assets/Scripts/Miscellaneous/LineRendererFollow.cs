using System;
using UnityEngine;
using UnityEngine.Events;

namespace Miscellaneous
{
    public class LineRendererFollow : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        [SerializeField]private Transform pointA, pointB;

        public UnityEvent changedEvent;
        private bool _isActive; 
        public void SetA(Transform target)
        {
            pointA = target;
            Refresh();
        }

        public void SetB(Transform target)
        {
            pointB = target;
            Refresh();
        }
        
        private void Refresh()
        {
            if (pointA == null || pointB == null)
            {
                lineRenderer.enabled = false;
                _isActive = false;
            }
            else
            {
                lineRenderer.enabled = true;
                _isActive = true;
            }
            changedEvent.Invoke();
        }
        private void Start()
        {
            lineRenderer.useWorldSpace = true;
            Refresh();
        }

        private void Update()
        {
            
            if (_isActive)
            {
                lineRenderer.SetPosition(0,pointA.position);
                lineRenderer.SetPosition(1,pointB.position);
            }
        }
        
    }
}