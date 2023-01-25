using Energy;
using UnityEngine;

namespace Connections.ConnectionSystem.Cable
{
    public class CableNodeConnector : MonoBehaviour
    {
        public GameObject ownerRoot;
        public Rigidbody2D rootRigidBody;
        public EnergyStorage energyStorage;
    }
}