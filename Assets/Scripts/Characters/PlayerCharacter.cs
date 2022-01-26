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
            // inventory.Add(item);
            if (shooter.item.itemType == ItemType.Weapon)
            {
                Debug.Log("Equipping weapon ...");
                shooter.equipped = true;
                obj.SetParent(itemSlot.transform);
                obj.position = itemSlot.position;
            }
        }

        public void Die()
        {
            
        }
    }
}
