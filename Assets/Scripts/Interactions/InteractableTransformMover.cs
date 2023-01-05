using System;
using UnityEngine;

namespace Interactions
{
    public class InteractableTransformMover : MonoBehaviour
    {
        [SerializeField] private Interactable interactable;
        [SerializeField] private Transform root;
        private bool _isSelected;
        private Vector2 mousePosition;
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
            _isSelected = interactable.areaSelected;
            print($"area: {_isSelected}");
        }


        private void Update()
        {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_isSelected)
            {
                root.position = mousePosition;
            }
        }
    }
}