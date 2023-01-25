using Interactions;
using UnityEngine;

namespace Connections.ConnectionSystem.Cable
{
    public class CableConnectorInteractionBreaker : MonoBehaviour
    {
        [SerializeField] private CableConnectionHandler connectionHandler;
        [SerializeField] private Interactable interactable;

        private void OnConnectionChanged()
        {
            var connected = connectionHandler.IsConnected;
            if (connected)
            {
                interactable.BreakSelection();
            }
        }
        
        private void OnEnable()
        {
            connectionHandler.ConnectionChangedEvent.AddListener(OnConnectionChanged);
        }

        private void OnDisable()
        {
            connectionHandler.ConnectionChangedEvent.RemoveListener(OnConnectionChanged);

        }
    }
}