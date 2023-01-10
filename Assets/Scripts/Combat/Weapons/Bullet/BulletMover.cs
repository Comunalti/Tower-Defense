using System;
using UnityEngine;

namespace Weapons
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform transformDirection;

        private void Update()
        {
        }

        private void OnEnable()
        {
            rigidbody2D.velocity = transformDirection.right * speed;
        }
        
        private void OnDisable()
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}