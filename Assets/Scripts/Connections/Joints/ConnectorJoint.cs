using UnityEngine;

namespace Connections.Joints
{
    public class ConnectorJoint : MonoBehaviour
    {
        [SerializeField] private ConnectionHandler connectionHandler;
        [SerializeField] private GameObject jointParent;
        [SerializeField] private JointCreator jointCreator;
        private Joint2D joint;

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
            print($" ConnectionChanged, CurrentConnectedHandler is: {connectionHandler.CurrentConnectedHandler}");
            if (connectionHandler.CurrentConnectedHandler != null)
            {
                joint = jointCreator.CreateJoint(jointParent,connectionHandler.GetOtherRigidbody());
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