using System;
using System.Collections;
using Characters;
using UnityEngine;

namespace World
{
    public class Spawner : MonoBehaviour
    {
        public Transform characterPrefab;
        private CharacterController2D characterController;

        public void Spawn()
        {
            var character = Instantiate(characterPrefab, transform.position, Quaternion.identity, null);
            characterController = character.GetComponent<CharacterController2D>();
        }
    }
}
