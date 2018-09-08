using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Draggable : MonoBehaviour
    {
        private float Speed = 5;

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
            Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            targetPosition = Camera.main.ScreenToWorldPoint(mouse) + offset;
            var currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
            rb.velocity = (targetPosition - transform.position) * Speed;

            if (Input.GetMouseButton(1))
            {
                targetRotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                targetRotation = initialRotation;
            }

            var angleDiff = targetRotation.eulerAngles.z - this.transform.rotation.eulerAngles.z;
            if (angleDiff > 180)
            {
                rb.angularVelocity = angleDiff - 360;
            }
            else
            {
                rb.angularVelocity = angleDiff;
            }

        }

        private void Update()
        {
        }
    }
}
