using UnityEngine;
using UnityEngine.Events;

namespace Energy.Consumer
{
    public abstract class EnergyConsumer : MonoBehaviour
    {
        public UnityEvent IsActiveStateChangedEvent;
        [field: SerializeField] public bool IsActive { get; protected set; }
    }
}