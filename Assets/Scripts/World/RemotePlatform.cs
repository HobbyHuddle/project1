using System;
using UnityEngine;

namespace World
{
    public class RemotePlatform : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Transform startPoint;
        public Transform endPoint;
        public float speed;
        public bool playerPresent;

        private void Update()
        {
            if (playerPresent)
            {
                MoveToNext();
            }
            else
            {
                MoveToStart();
            }
        }

        public void ToggleSlide()
        {
            playerPresent = !playerPresent;
        }
        
        private void MoveToStart()
        {
            Vector2 destination = startPoint.position;
            transform.position = Vector2.MoveTowards(rb.position, destination, speed * Time.deltaTime);
        }

        private void MoveToNext()
        {
            Vector2 destination = endPoint.position;
            transform.position = Vector2.MoveTowards(rb.position, destination, speed * Time.deltaTime);
        }
    }
}
