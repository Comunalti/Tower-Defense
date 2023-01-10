using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions.Movers.Managers
{
    public class InteractableJoint2DMoverManager : Singleton<InteractableJoint2DMoverManager>
    {
        [SerializeField] private RelativeJoint2D joint2D;
        [SerializeField] private Transform mouseTarget;
        private Rigidbody2D attachedRigidbody2D;

        public Rigidbody2D AttachedRigidbody2D => attachedRigidbody2D;

        public UnityEvent attachedRigidbodyChangedEvent;
        private void Update()
        {
            mouseTarget.position = InteractableMoverManager.Instance.MouseWorldPosition;
        }

        public void AttachRigidbody(Rigidbody2D rigidbody2D)
        {
            attachedRigidbody2D = rigidbody2D;
            joint2D.connectedBody = rigidbody2D;
            attachedRigidbodyChangedEvent.Invoke();
        }

        public void DeAttachRigidbody(Rigidbody2D rigidbody2D)
        {
            if (attachedRigidbody2D == rigidbody2D)
            {
                attachedRigidbody2D = null;
                joint2D.connectedBody = null;
                attachedRigidbodyChangedEvent.Invoke();
            }
        }
    }
}