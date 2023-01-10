using System;
using Interactions.Movers.Managers;
using UnityEngine;

namespace Interactions.Movers
{
    public class InteractableRigidbodyMover : InteractableMover
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
        }


        private void Update()
        {
            if (isSelected)
            {
                var mousePosition = InteractableMoverManager.Instance.MouseWorldPosition;
                root.MovePosition(mousePosition);
            }
        }
    }
}