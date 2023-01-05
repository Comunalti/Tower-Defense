using UnityEngine;
using UnityEngine.Events;

namespace Connections
{
    public abstract class ConnectionHandler : MonoBehaviour
    {
        [SerializeField] protected ConnectionHandler connectedHandler;
        public ConnectionHandler ConnectedHandler => connectedHandler;
        public bool IsConnected => connectedHandler != null;

        [SerializeField] protected NodeConnector nodeConnector;

        public UnityEvent ConnectionChangedEvent;

        public Rigidbody2D GetOtherRigidbody()
        {
            return connectedHandler.nodeConnector.GetComponentInChildren<Rigidbody2D>();
        }

        protected void TryConnectTo(ConnectionHandler connectionHandler)
        { //todo: make this not connect when, it is already connected to something and add a flag for color
            if (connectionHandler != null)
            {
                connectedHandler = connectionHandler;
                ConnectionChangedEvent.Invoke();
            }
        }

        protected void TryDisconnectTo(ConnectionHandler connectionHandler)
        {
            if (connectionHandler != null)
            {
                if (connectionHandler == connectedHandler)
                {
                    connectedHandler = null;
                    ConnectionChangedEvent.Invoke();
                }
            }
        }
    }
}