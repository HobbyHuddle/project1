using UnityEngine;

namespace World
{
    public class CompositePlatform : Platform
    {
        // Start is called before the first frame update
        void Start()
        {
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
            gameObject.SetActive(true);
        }
    }
}
