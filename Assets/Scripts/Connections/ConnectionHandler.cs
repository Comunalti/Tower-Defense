using UnityEngine;
using UnityEngine.Events;

namespace Connections
{
    public abstract class ConnectionHandler : MonoBehaviour
    {
        [SerializeField] protected ConnectionHandler connectedHandler;
        public ConnectionHandler ConnectedHandler => connectedHandler;
        
        [SerializeField] protected NodeConnector nodeConnector;

        public UnityEvent ConnectionChangedEvent;
    }
}