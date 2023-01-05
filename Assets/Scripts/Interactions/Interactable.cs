using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class Interactable : MonoBehaviour
    {
        public enum InteractionMode {
            // None = 0,
            // Transform = 1,
            //Rigidbody2D = 2,
            Target = 3,
        }
        
        [SerializeField] private GameObject root;
        [SerializeField] private InteractionMode mode;

        public bool areaHovered;
        public bool areaSelected;
        
        public UnityEvent AreaHoveringChangedEvent;
        public UnityEvent AreaSelectingChangedEvent;


        private void OnEnable()
        {
            InteractionManager.Instance.HoveringChangedEvent.AddListener(Refresh);
            InteractionManager.Instance.SelectingChangedEvent.AddListener(Refresh);
        }

        private void OnDisable()
        {
            InteractionManager.Instance.HoveringChangedEvent.RemoveListener(Refresh);
            InteractionManager.Instance.SelectingChangedEvent.RemoveListener(Refresh);
        }

        void Refresh()
        {
            var areaHoveredBefore= areaHovered;
            var areaSelectedBefore= areaSelected;

            areaHovered = this == InteractionManager.Instance.Hovered;
            areaSelected = this == InteractionManager.Instance.Selected;

            //print($"area hovered: {areaHovered}, area Selected: {areaSelected}");
            
            if (areaHoveredBefore != areaHovered)
            {
                AreaHoveringChangedEvent.Invoke();
            }
            if (areaSelectedBefore != areaSelected)
            {
                AreaSelectingChangedEvent.Invoke();
            }
        }

        public void MouseEnter()
        {
            // print("mouse enter");
            InteractionManager.Instance.SetHover(this);
        }

        public void MouseExit()
        {
            // print("mouse exit");

            if (InteractionManager.Instance.Hovered == this)
            {
                InteractionManager.Instance.SetHover(null);
            }
        }

        public void MouseDown()
        {
            // print("mouse down");

            InteractionManager.Instance.SetSelect(this);
        }

        public void MouseUp()
        {
            // print("mouse up");

            if (InteractionManager.Instance.Selected == this)
            {
                InteractionManager.Instance.SetSelect(null);
            }
        }

        public void BreakSelection()
        {
            MouseUp();
        }
    }
}