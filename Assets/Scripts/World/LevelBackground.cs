using System;
using UnityEngine;
using UnityEngine.Events;

namespace World
{
    [Serializable]
    public class BackgroundColorEvent : UnityEvent<Color> {}
    
    public class LevelBackground : MonoBehaviour
    {
        public Color defaultColor;
        public Color currentColor;
        public BackgroundColorEvent OnBackgroundColorChange;
    }
}
