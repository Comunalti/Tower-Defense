using Core;
using Interactions.Movers;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class InteractionManager : Singleton<InteractionManager>
    {
        public enum InteractionManagerState{
            Free,
            Hovering,
            Selecting,
        }
        
        public InteractionManagerState interactionManagerState;

        [field: SerializeField] public Interactable Hovered { get; private set; }
        [field: SerializeField] public Interactable Selected { get; private set; }

        public UnityEvent HoveringChangedEvent;
        public UnityEvent SelectingChangedEvent;

        
        void Refresh()
        {
            if (Selected != null)
            {
                interactionManagerState = InteractionManagerState.Selecting;
            }
            else if (Hovered != null)
            {
                interactionManagerState = InteractionManagerState.Hovering;
            }
            else
            {
                interactionManagerState = InteractionManagerState.Free;
            }
        }

        public void SetHover(Interactable interactable)
        {
            Hovered = interactable;
            HoveringChangedEvent.Invoke();
            Refresh();
        }
        
        public void SetSelect(Interactable interactable)
        {
            Selected = interactable;
            SelectingChangedEvent.Invoke();
            Refresh();
        }
    }
}