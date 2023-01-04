using System;
using UnityEngine;

namespace Connections
{
    public class ConnectorJoint : MonoBehaviour
    {
        [SerializeField] private ConnectionHandler connectionHandler;
        [SerializeField] private Transform connectedTransform;
        private void OnEnable()
        {
            connectionHandler.ConnectionChangedEvent.AddListener(OnConnectionChanged);
        }
        
        private void OnDisable()
        {
            connectionHandler.ConnectionChangedEvent.RemoveListener(OnConnectionChanged);
        }

        private void OnConnectionChanged()
        {
            if (connectionHandler.ConnectedHandler != null)
            {
                var distanceJoint2D = gameObject.AddComponent<DistanceJoint2D>();
                distanceJoint2D.distance = 0;
                distanceJoint2D.autoConfigureDistance = false;
                distanceJoint2D.connectedBody = connectionHandler.ConnectedHandler.GetComponent<Rigidbody2D>();
                distanceJoint2D.breakForce = 25000;
            }
            else
            {
                
            }
        }
    }
}