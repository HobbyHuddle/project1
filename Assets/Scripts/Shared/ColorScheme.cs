using UnityEngine;

namespace Shared
{
    [CreateAssetMenu(fileName = "New Color Scheme", menuName = "Game/Color Scheme")]
    public class ColorScheme : ScriptableObject
    {
        [Header("Major Colors")]
        public Color color1;
        public Color color2;
        public Color color3;
        public Color color4;
        public Color color5;

        [Header("Minor Colors")] 
        public Color minorColor1;
        public Color minorColor2;
        public Color minorColor3;
    }
}