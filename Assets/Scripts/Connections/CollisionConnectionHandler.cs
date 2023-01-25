// using UnityEngine;
// using UnityEngine.Events;
//
// namespace Connections
// {
//     public class CollisionConnectionHandler : ConnectionHandler
//     {
//
//         private void OnCollisionEnter2D(Collision2D other)
//         {
//             var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
//             
//             TryConnectTo(connectionHandler);
//         }
//
//         private void OnCollisionExit2D(Collision2D other)
//         {
//             var connectionHandler = other.gameObject.GetComponent<ConnectionHandler>();
//             
//             TryConnectTo(connectionHandler);
//         }
//     }
// }