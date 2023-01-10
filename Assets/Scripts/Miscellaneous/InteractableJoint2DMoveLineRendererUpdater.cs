using Interactions.Movers.Managers;
using UnityEngine;

namespace Miscellaneous
{
    public class InteractableJoint2DMoveLineRendererUpdater: MonoBehaviour
    {
        [SerializeField] private InteractableJoint2DMoverManager interactableJoint2DMoverManager;
        [SerializeField] private LineRendererFollow lineRendererFollow;

        private void OnEnable()
        {
            interactableJoint2DMoverManager.attachedRigidbodyChangedEvent.AddListener(OnAttachedRigidbodyChanged);
        }

        private void OnAttachedRigidbodyChanged()
        {
            if (interactableJoint2DMoverManager.AttachedRigidbody2D == null)
            {
                lineRendererFollow.SetB(null);
            }
            else
            {
                lineRendererFollow.SetB(interactableJoint2DMoverManager.AttachedRigidbody2D.transform);
            }
        }
    }
}