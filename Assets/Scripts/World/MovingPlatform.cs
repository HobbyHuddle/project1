using System;
using UnityEngine;

namespace World
{
    public class MovingPlatform : Platform
    {
        public Rigidbody2D rb;
        public Transform startPoint;
        public Transform endPoint;
        public float speed;

        private bool atStart = true;
        private bool atEnd;

        private void FixedUpdate()
        {
            if (atStart)
            {
                MoveToNext();
            }

            if (atEnd)
            {
                MoveToStart();
            }
        }

        private void MoveToStart()
        {
            Vector2 destination = startPoint.position;
            if (rb.position == destination)
            {
                atEnd = false;
                atStart = true;
            }
            else
            {
                Debug.Log("Moving to start ...");
                rb.position = Vector2.MoveTowards(rb.position, destination, speed * Time.deltaTime);
            }
        }

        private void MoveToNext()
        {
            Vector2 destination = endPoint.position;
            if (rb.position == destination)
            {
                atEnd = true;
                atStart = false;
            }
            else
            {
                Debug.Log("Moving to next ...");
                rb.position = Vector2.MoveTowards(rb.position, destination, speed * Time.deltaTime);
            }
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                // col.gameObject.transform.SetParent(gameObject.transform);
            }
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                // col.gameObject.transform.parent = null;
            }
        }
        
    }
}