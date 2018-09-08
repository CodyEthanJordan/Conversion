using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Draggable : MonoBehaviour
    {
        public float Speed = 1;

        private Vector3 offset;
        private Rigidbody2D rb;
        private Quaternion initialRotation;

        private Quaternion targetRotation;
        private Vector3 targetPosition;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnMouseDown()
        {
            initialRotation = transform.rotation;

            offset = gameObject.transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }

        void OnMouseDrag()
        {
            //Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            //transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
            //rb.velocity = Vector2.zero;
            //transform.rotation = initialRotation;

        }

        private void Update()
        {
        }
    }
}
