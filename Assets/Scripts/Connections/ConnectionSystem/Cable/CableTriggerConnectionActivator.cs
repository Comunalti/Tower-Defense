using Connections.ConnectionSystem.Base;
using UnityEngine;

namespace Connections.ConnectionSystem.Cable
{
    public class CableTriggerConnectionActivator : MonoBehaviour
    {
        [SerializeField] private CableConnectionHandler cableConnectionHandlerBase;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<BaseConnectionHandler>();
            
            cableConnectionHandlerBase.TryConnectTo(connectionHandler);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<BaseConnectionHandler>();

            cableConnectionHandlerBase.TryDisconnectTo(connectionHandler);
        }

    }
}