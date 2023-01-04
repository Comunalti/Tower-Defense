using UnityEngine;

namespace Connections
{
    public class TriggerConnectionHandler : ConnectionHandler
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
            if (connectionHandler != null)
            {
                connectedHandler = connectionHandler;
                ConnectionChangedEvent.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
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