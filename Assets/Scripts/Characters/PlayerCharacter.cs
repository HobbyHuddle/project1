using System.Collections.Generic;
using DataModels;
using UnityEngine;

namespace Characters
{
    public class PlayerCharacter : MonoBehaviour
    {
        public List<ItemData> inventory;
        public Transform itemSlot;
        
        public void CollectItem(Transform obj)
        {
            var shooter = obj.GetComponent<ShooterScript>();
            inventory.Add(shooter.item);
            if (shooter.item.itemType == ItemType.Weapon)
            {
                Debug.Log("Equipping weapon ...");
                // re-register item events
                var controller = GetComponent<CharacterController2D>();
                controller.onDeath.AddListener(shooter.RespawnOnDeath);
                // reposition and make equip
                shooter.equipped = true;
                obj.SetParent(itemSlot.transform);
                obj.position = itemSlot.position;
            }
        }
    }
}
