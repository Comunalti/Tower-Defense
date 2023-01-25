// using UnityEngine;
// using UnityEngine.Events;
//
// namespace Connections
// {
//     public abstract class ConnectionHandler : MonoBehaviour
//     {
//         public enum ConnectionColor
//         {
//             NoColor,
//             Yellow,
//             Blue,
//         }
//         public enum ConnectionType
//         {
//             Mobile,
//             Fixed,
//         }
//
//         [SerializeField] public ConnectionColor connectionColor;
//         [SerializeField] public ConnectionType connectionType;
//
//         
//         [SerializeField] protected ConnectionHandler currentConnectedHandler;
//         public ConnectionHandler CurrentConnectedHandler => currentConnectedHandler;
//         public bool IsConnected => currentConnectedHandler != null;
//
//         [SerializeField] protected NodeConnector nodeConnector;
//
//         public NodeConnector NodeConnector => nodeConnector;
//
//         public UnityEvent ConnectionChangedEvent;
//
//         public Rigidbody2D GetOtherRigidbody()
//         {
//             return currentConnectedHandler.nodeConnector.rootRigidBody;
//         }
//         
//
//         public void TryConnectTo(ConnectionHandler connectionHandler)
//         { 
//             if (IsConnected)
//             {
//                 return;
//             }
//             
//             if (connectionHandler == null)
//             {
//                 return;
//             }
//
//             if (connectionHandler.connectionColor != connectionColor)
//             {
//                 return;
//             }
//
//             if (connectionHandler.connectionType == connectionType)
//             {
//                 return;
//             }
//
//             currentConnectedHandler = connectionHandler;
//             ConnectionChangedEvent.Invoke();
//         }
//
//         public void TryDisconnectTo(ConnectionHandler connectionHandler)
//         {
//             if (connectionHandler != null)
//             {
//                 if (connectionHandler == currentConnectedHandler)
//                 {
//                     currentConnectedHandler = null;
//                     ConnectionChangedEvent.Invoke();
//                 }
//             }
//         }
//
//         public void DisconnectBoth()
//         {
//             if (currentConnectedHandler != null)
//             {
//                 var temp = currentConnectedHandler;
//                 currentConnectedHandler = null;
//                 temp.DisconnectBoth();
//                 ConnectionChangedEvent.Invoke();
//             }
//         }
//     }
// }