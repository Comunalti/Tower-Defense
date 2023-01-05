using System;
using Interactions;
using UnityEngine;

namespace Connections
{
    public class ConnectorInteractionBreaker : MonoBehaviour
    {
        [SerializeField] private ConnectionHandler connectionHandler;
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