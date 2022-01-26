using UnityEngine;

namespace DataModels
{
    public enum ItemType { Weapon, PowerUp }
    
    /// <summary>
    /// Used to create and define new game items.
    /// </summary>
    [CreateAssetMenu(fileName = "New Item", menuName = "Game/Item")]
    public class ItemData : ScriptableObject
    {
        public new string name;
        public string description;
        public ItemType itemType;
        public Sprite icon;
        public Color color;
    }
}
