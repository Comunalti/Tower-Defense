using Energy;
using UnityEngine;

namespace Connections.ConnectionSystem.Base
{
    public class BaseNodeConnector : MonoBehaviour
    {
        public GameObject ownerRoot;
        public Rigidbody2D rootRigidBody;
        public EnergyStorage energyStorage;
    }
}