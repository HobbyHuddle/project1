using System;
using UnityEngine;
using UnityEngine.Events;

namespace World
{
    [Serializable]
    public class ColorSwitchEvent : UnityEvent<Color> {}
    
    public class ColorSwitch : MonoBehaviour
    {
        public Color onColor;
        public Color offColor;
        public Color currentColor;
        public bool switchOn;
        public bool playerPresent;
        public ColorSwitchEvent onSwitch;

        private void Update()
        {
            if (switchOn)
            {
                currentColor = onColor;
            }
            else
            {
                currentColor = offColor;
            }
            
            if (Input.GetKeyDown(KeyCode.J) && playerPresent)
            {
                ToggleSwitch();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerPresent = true;
                Debug.Log("Player entered.");
            }
            else
            {
                playerPresent = false;
            }
        }

        private void ToggleSwitch()
        {
            switchOn = !switchOn;
            onSwitch.Invoke(currentColor);
        }
    }
}
