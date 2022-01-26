using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<SpriteRenderer> spriteRenderers;
        private bool active;

        public LandingEvent onLandingEvent;
        
        private void Start()
        {
            active = isActiveAndEnabled;
            spriteRenderer.color = defaultColor;
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
            UpdateSpriteColors(defaultColor);
        }

        private void UpdateSpriteColors(Color color)
        {
            foreach (var spriteRenderer1 in spriteRenderers)
            {
                spriteRenderer1.color = color;
            }
        }

        public void ActivateColor(Color color)
        {
            spriteRenderer.color = color;
            UpdateSpriteColors(color);
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