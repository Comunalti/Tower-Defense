using Connections.ConnectionSystem.Base;
using UnityEngine;

namespace Connections.Joints
{
    public class BaseConnectorJoint : MonoBehaviour
    {
        [SerializeField] private BaseConnectionHandler baseConnectionHandler;
        [SerializeField] private GameObject jointParent;
        [SerializeField] private JointCreator jointCreator;
        private Joint2D joint;

        private void OnEnable()
        {
            baseConnectionHandler.ConnectionChangedEvent.AddListener(OnConnectionChanged);
        }
        
        private void OnDisable()
        {
            baseConnectionHandler.ConnectionChangedEvent.RemoveListener(OnConnectionChanged);
        }

        private void OnConnectionChanged()
        {
            print($" ConnectionChanged, CurrentConnectedHandler is: {baseConnectionHandler.currentCableConnectedHandler}");
            if (baseConnectionHandler.currentCableConnectedHandler != null)
            {
                joint = jointCreator.CreateJoint(jointParent,baseConnectionHandler.currentCableConnectedHandler.CableNodeConnector.rootRigidBody);
            }
            else
            {
                // print($"destroy joint, current joint is: {joint}");
                if (joint != null)
                {
                    // print("forced disconnect");
                    Destroy(joint);
                }
            }
        }
    }
}