using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Interactions
{
    // public class InteractionRaycaster : MonoBehaviour
    // {
    //     [SerializeField] private LayerMask layerMask;
    //     //[SerializeField] private DoubleBufferArray<RaycastHit2D> doubleBufferRaycasts;
    //     // [SerializeField] private RaycastHit2D[] currentFrame;
    //     [SerializeField] private Interactable[] lastFrameInteractables;
    //     [SerializeField] private Interactable[] currentFrameInteractables;
    //
    //     
    //     
    //     void Update()
    //     {
    //         Vector3 mousePos = Input.mousePosition;
    //
    //         Vector2 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);
    //         
    //         // Perform the 2D Raycast using the layer mask and distance
    //         var hits = Physics2D.RaycastAll(mousePos3D, Vector2.zero, 0.0f, layerMask);
    //
    //         if (hits.Length == 0)
    //             return;
    //
    //         currentFrameInteractables = new Interactable[hits.Length];
    //
    //         for (var i = 0; i < hits.Length; i++)
    //         {
    //             var hit = hits[i];
    //             currentFrameInteractables[i] = hit.transform.GetComponent<Interactable>();
    //         }
    //
    //         foreach (var interactable in currentFrameInteractables)    
    //         {
    //             if (!lastFrameInteractables.Contains(interactable))
    //             {
    //                 interactable.MouseEnter();
    //             }
    //         }
    //         
    //         
    //         foreach (var lastFrameInteractable in lastFrameInteractables)    
    //         {
    //             if (currentFrameInteractables.Contains(lastFrameInteractable))
    //             {
    //                 lastFrameInteractable.MouseExit();
    //             }
    //         }
    //
    //         if (Input.GetMouseButtonDown())
    //         {
    //             
    //         }
    //     }
    // }
    
    public class InteractionRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        //[SerializeField] private DoubleBufferArray<RaycastHit2D> doubleBufferRaycasts;
        // [SerializeField] private RaycastHit2D[] currentFrame;
        [SerializeField] private Interactable lastFrameInteractable;
        [SerializeField] private Interactable currentFrameInteractable;
        [SerializeField] private Interactable recordedInteractable;

        private new Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            Vector3 mousePos = Input.mousePosition;

            Vector2 mousePos3D = _camera.ScreenToWorldPoint(mousePos);
            
            var hit = Physics2D.Raycast(mousePos3D, Vector2.zero, 0.0f, layerMask);


            var hitTransform = hit.transform;

            if (hitTransform == null)
            {
                currentFrameInteractable = null;
            }
            else
            {
                currentFrameInteractable = hitTransform.GetComponent<Interactable>();
            }
            

            if (lastFrameInteractable != currentFrameInteractable)
            {
                if (lastFrameInteractable != null)
                {
                    lastFrameInteractable.MouseExit();
                }

                if (currentFrameInteractable != null)
                {
                    currentFrameInteractable.MouseEnter();
                }
            }
            
            
            if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
            {
                if (currentFrameInteractable != null)
                {
                    recordedInteractable = currentFrameInteractable;
                    currentFrameInteractable.MouseDown();
                }
            }
            if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
            {
                if (recordedInteractable != null)
                {
                    recordedInteractable.MouseUp();
                    recordedInteractable = null;
                }
            }

            lastFrameInteractable = currentFrameInteractable;
        }
    }
}