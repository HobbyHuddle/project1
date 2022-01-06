using System.Collections.Generic;
using DataModels;
using UnityEngine;

namespace Characters
{
    public class PlayerCharacter : MonoBehaviour
    {
        public List<ItemData> inventory;


        public void CollectItem(ItemData item)
        {
            inventory.Add(item);
        }
    }
}
