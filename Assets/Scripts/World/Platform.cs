using UnityEngine;

namespace World
{
    public class Platform : MonoBehaviour
    {
        public Color defaultColor;
        public Color currentColor;
        public SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer.color = defaultColor;
        }

        public void ActivateColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}