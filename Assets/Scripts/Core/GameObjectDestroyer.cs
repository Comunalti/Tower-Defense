using UnityEngine;

namespace Core
{
    public class GameObjectDestroyer : MonoBehaviour
    {
        public GameObject target;
        [ContextMenu("Destroy target")]
        public void DestroyGameObject()
        {
            Destroy(target);
        }
    }
}