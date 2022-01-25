using UnityEngine;

namespace World
{
    public class CompositePlatform : Platform
    {
        public bool isActive;
        void Start()
        {
            isActive = isActiveAndEnabled;
            Platform[] platforms = GetComponentsInChildren<Platform>();
            foreach (Platform platform in platforms)
            {
                platform.defaultColor = defaultColor;
            }
        }

        public new void ActivateColor(Color color)
        {
            var platforms = GetComponentsInChildren<Platform>();
            foreach (Platform platform in platforms)
            {
                platform.spriteRenderer.color = color;
            }
            ToggleActive();
        }

        private void ToggleActive()
        {
            isActive = !isActive;
            gameObject.SetActive(isActive);
        }
    }
}
