using UnityEngine;

namespace Connections.Joints
{
    public abstract class JointCreator : MonoBehaviour
    {
        public abstract Joint2D CreateJoint(GameObject parent, Rigidbody2D connectedBody);
    }
}