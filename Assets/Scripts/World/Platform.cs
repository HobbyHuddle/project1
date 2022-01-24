using System;
using UnityEngine;
using UnityEngine.Events;

namespace World
{
    [Serializable]
    public class LandingEvent : UnityEvent<bool> {}
    
    public class Platform : MonoBehaviour
    {
        public Color defaultColor;
        public Color currentColor;
        public SpriteRenderer spriteRenderer;
        private bool active;

        public LandingEvent onLandingEvent;
        
        private void Start()
        {
            active = isActiveAndEnabled;
            spriteRenderer.color = defaultColor;
        }

        public void ActivateColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void Activate()
        {
            active = !active;
            gameObject.SetActive(active);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
                onLandingEvent.Invoke(false); // set platform inactive
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            // FIXME: This collision exit event isn't happening at all. Why?
            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("Leaving platform ...");
                onLandingEvent.Invoke(true);
            }
        }
    }
}