using UnityEngine;

namespace Miscellaneous
{
    public class RopeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject ropeSegmentPrefab;
        [SerializeField] private GameObject ropeStart;
        [SerializeField] private GameObject ropeEnd;
        [SerializeField] private int segmentCount;
        [SerializeField] private Vector2 segmentSize;
        [SerializeField] private Transform parent;
        private void Start()
        {

            var lastSegment = ropeStart;
            for (int i = 0; i < segmentCount; i++)
            {
                var newSegment = Instantiate(ropeSegmentPrefab, parent);
                var body = lastSegment.GetComponent<Rigidbody2D>();
                newSegment.GetComponent<HingeJoint2D>().connectedBody = body;
                lastSegment = newSegment;
            }

            var lastBody = lastSegment.GetComponent<Rigidbody2D>();
            var hingeJoint2D = lastSegment.GetComponent<HingeJoint2D>();


            var joint2D = ropeEnd.AddComponent<HingeJoint2D>();
            joint2D.autoConfigureConnectedAnchor = false;
            joint2D.anchor = hingeJoint2D.anchor;
            joint2D.connectedAnchor = hingeJoint2D.connectedAnchor;
        
            joint2D.connectedBody = lastBody;

        }
    }
}
