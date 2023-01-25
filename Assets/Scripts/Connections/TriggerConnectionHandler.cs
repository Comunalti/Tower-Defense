// using UnityEngine;
//
// namespace Connections
// {
//     public class TriggerConnectionHandler : ConnectionHandler
//     {
//
//         private void OnTriggerEnter2D(Collider2D other)
//         {
//             var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
//             
//             TryConnectTo(connectionHandler);
//         }
//         
//         private void OnTriggerExit2D(Collider2D other)
//         {
//             var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
//             
//             TryDisconnectTo(connectionHandler);
//         }
//         
//     }
// }