using UnityEngine;

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
            currentColor = color;  // TODO: may not need this property any more
            spriteRenderer.color = color;
        }
}