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
            if (Input.GetKeyDown(KeyCode.J) && playerPresent)
            {
                ToggleSwitch();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                playerPresent = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                playerPresent = false;
        }

        private void ToggleSwitch()
        {
            switchOn = !switchOn;
            currentColor = switchOn switch
            {
                true => onColor,
                false => offColor,
            };
            onSwitch.Invoke(currentColor);
        }
    }
}
