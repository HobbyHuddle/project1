using UnityEngine;

namespace Data
{
    /// <summary>
    /// Used to create and define new game items.
    /// </summary>
    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemData : ScriptableObject
    {
        public new string name;
        public string description;
        public Sprite icon;
        public Color color;
    }
}
