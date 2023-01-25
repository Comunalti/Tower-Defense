using Connections.ConnectionSystem.Cable;
using UnityEngine;
using UnityEngine.Events;

namespace Connections.ConnectionSystem.Base
{
    public class BaseConnectionHandler : MonoBehaviour
    {
        public CableConnectionHandler currentCableConnectedHandler;
        public bool IsConnected => currentCableConnectedHandler != null;
        [field:SerializeField] public BaseNodeConnector BaseNodeConnector { get; private set; }

        public UnityEvent ConnectionChangedEvent;
        
        public string connectionKey;
        public string key;
        
        public void TryConnectTo(CableConnectionHandler connectionHandler)
        { 
            if (IsConnected)
            {
                return;
            }
            
            if (connectionHandler == null)
            {
                return;
            }

            if (connectionHandler.key != connectionKey)
            {
                return;
            }

            if (connectionHandler.connectionKey != key)
            {
                return;
            }

            currentCableConnectedHandler = connectionHandler;
            ConnectionChangedEvent.Invoke();
        }

        public void TryDisconnectTo(CableConnectionHandler connectionHandler)
        {
            if (connectionHandler != null)
            {
                if (connectionHandler == currentCableConnectedHandler)
                {
                    currentCableConnectedHandler = null;
                    ConnectionChangedEvent.Invoke();
                }
            }
        }
        
        public void DisconnectBoth()
        {
            if (currentCableConnectedHandler != null)
            {
                var temp = currentCableConnectedHandler;
                currentCableConnectedHandler = null;
                temp.DisconnectBoth();
                ConnectionChangedEvent.Invoke();
            }
        }
    }
}