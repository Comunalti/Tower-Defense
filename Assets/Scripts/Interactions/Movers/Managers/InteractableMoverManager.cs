using Core;
using UnityEngine;

namespace Interactions.Movers.Managers
{
    public class InteractableMoverManager : Singleton<InteractableMoverManager>
    {
        private new Camera camera;
        
        
        [field: SerializeField] public Vector2 MouseWorldPosition { get; private set; }

        protected override void OnAwake()
        {
            camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            MouseWorldPosition=camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}