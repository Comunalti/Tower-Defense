using Connections.ConnectionSystem.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Connections.ConnectionSystem.Cable
{
    public class CableConnectionHandler : MonoBehaviour
    {
        public BaseConnectionHandler currentBaseConnectedHandler;
        public bool IsConnected => currentBaseConnectedHandler != null;
        [field:SerializeField] public CableNodeConnector CableNodeConnector { get; private set; }

        public UnityEvent ConnectionChangedEvent;
        public string connectionKey;
        public string key;


        public void TryConnectTo(BaseConnectionHandler connectionHandler)
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

            currentBaseConnectedHandler = connectionHandler;
            ConnectionChangedEvent.Invoke();
        }

        public void TryDisconnectTo(BaseConnectionHandler connectionHandler)
        {
            if (connectionHandler != null)
            {
                if (connectionHandler == currentBaseConnectedHandler)
                {
                    currentBaseConnectedHandler = null;
                    ConnectionChangedEvent.Invoke();
                }
            }
        }
        
        public void DisconnectBoth()
        {
            if (currentBaseConnectedHandler != null)
            {
                var temp = currentBaseConnectedHandler;
                currentBaseConnectedHandler = null;
                temp.DisconnectBoth();
                ConnectionChangedEvent.Invoke();
            }
        }
    }
}