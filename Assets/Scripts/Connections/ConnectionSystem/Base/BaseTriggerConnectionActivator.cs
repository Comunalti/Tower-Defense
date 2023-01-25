using Connections.ConnectionSystem.Cable;
using UnityEngine;

namespace Connections.ConnectionSystem.Base
{
    public class BaseTriggerConnectionActivator : MonoBehaviour
    {
        [SerializeField] private BaseConnectionHandler baseConnectionHandlerBase;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<CableConnectionHandler>();
            
            baseConnectionHandlerBase.TryConnectTo(connectionHandler);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<CableConnectionHandler>();

            baseConnectionHandlerBase.TryDisconnectTo(connectionHandler);
        }

    }
}