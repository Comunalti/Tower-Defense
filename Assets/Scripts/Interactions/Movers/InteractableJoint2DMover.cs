using Interactions.Movers.Managers;
using UnityEngine;

namespace Interactions.Movers
{
    public class InteractableJoint2DMover : InteractableMover
    {
        [SerializeField] private Interactable interactable;
        [SerializeField] private Rigidbody2D root;
        private void OnEnable()
        {
            interactable.AreaSelectingChangedEvent.AddListener(OnAreaSelected);
        }
        private void OnDisable()
        {
            interactable.AreaSelectingChangedEvent.RemoveListener(OnAreaSelected);
        }
        private void OnAreaSelected()
        {
            isSelected = interactable.areaSelected;
            if (isSelected)
            {
                InteractableJoint2DMoverManager.Instance.AttachRigidbody(root);
            }
            else
            {
                InteractableJoint2DMoverManager.Instance.DeAttachRigidbody(root);

            }
        }
    }
}