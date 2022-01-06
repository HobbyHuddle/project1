using System;
using Characters;
using DataModels;
using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    [Serializable]
    public class CollectibleItemEvent : UnityEvent<Color> {}
    
    public class CollectibleItem : MonoBehaviour
    {
        public ItemData item;
        public BoxCollider2D collider2d;
        public CollectibleItemEvent onColorInteraction;

        // Start is called before the first frame update
        void Start()
        {
            collider2d = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                onColorInteraction.Invoke(item.color);
                var player = col.gameObject.GetComponent<PlayerCharacter>();
                player.CollectItem(item);
                Destroy(gameObject);
            }
        }
    }
}
