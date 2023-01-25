using Connections.ConnectionSystem.Cable;
using Interactions;
using UnityEngine;

namespace Connections
{
    public class CableInteractorConnectionBreaker : MonoBehaviour
    {
        [SerializeField] private CableConnectionHandler connectionHandler;
        [SerializeField] private Interactable interactable;
        
        private void OnAreaSelectingChanged()
        {
            // print($"area selection changed value is: {interactable.areaSelected}");
            if (interactable.areaSelected)
            {
                connectionHandler.DisconnectBoth();
            }
        }
        private void OnEnable()
        {
            interactable.AreaSelectingChangedEvent.AddListener(OnAreaSelectingChanged);
        }
        
        private void OnDisable()
        {
            interactable.AreaSelectingChangedEvent.RemoveListener(OnAreaSelectingChanged);
        }
    }
}