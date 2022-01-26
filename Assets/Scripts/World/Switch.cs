using System;
using UnityEngine;
using UnityEngine.Events;

namespace World
{
    [Serializable]
    public class SwitchEvent : UnityEvent {}
    
    public class Switch : MonoBehaviour
    {
        public bool active;
        public bool playerPresent;
        public SwitchEvent onSwitch;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J) && playerPresent)
            {
                ToggleSwitch();
            }
        }
        
        private void ToggleSwitch()
        {
            // active = !active;
            // gameObject.SetActive(active);
            onSwitch.Invoke();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                playerPresent = true;
            if (other.CompareTag("Projectile"))
            {
                ToggleSwitch();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                playerPresent = false;
        }
    }
}