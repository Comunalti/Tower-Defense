using UnityEngine;

namespace Miscellaneous
{
    public class LineRendererFollow : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        [SerializeField]private Transform pointA, pointB;

        private void Start()
        {
            lineRenderer.useWorldSpace = true;
        }

        private void Update()
        {
            lineRenderer.SetPosition(0,pointA.position);
            lineRenderer.SetPosition(1,pointB.position);
        }
    }
}