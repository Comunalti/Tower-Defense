using UnityEngine;

namespace Connections.Joints
{
    public class HingeJointCreator : JointCreator
    {
        [SerializeField] private float breakForce;

        public override Joint2D CreateJoint(GameObject parent,Rigidbody2D connectedBody)
        {
            var joint = parent.AddComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = connectedBody;
            joint.connectedAnchor = Vector2.zero;
            joint.breakForce = breakForce;
            return joint;
        }
    }
}