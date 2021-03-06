using System;
using Characters;
using UnityEngine;

namespace World
{
    public enum DamageType { Spikes }
    
    public class WorldHazard : MonoBehaviour
    {
        public DamageType damageType;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var player = col.GetComponent<CharacterController2D>();
                Debug.Log("Player has died by " + damageType);
                player.Die();
            }
        }
    }
}
