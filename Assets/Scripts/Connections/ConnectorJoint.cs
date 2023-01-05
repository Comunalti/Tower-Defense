using System;
using UnityEngine;

namespace Connections
{
    public class ConnectorJoint : MonoBehaviour
    {
        [SerializeField] private ConnectionHandler connectionHandler;
        [SerializeField] private int breakForce = 45000;

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
                var joint = gameObject.AddComponent<DistanceJoint2D>();
                joint.distance = 0;
                joint.autoConfigureDistance = false;
                joint.connectedBody = connectionHandler.GetOtherRigidbody();
                joint.breakForce = breakForce;
            }
            else
            {
                
            }
        }
    }
}