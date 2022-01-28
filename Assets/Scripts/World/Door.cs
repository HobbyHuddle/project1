using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class Door : MonoBehaviour
    {
        public string sceneName;
        public int sceneNumber;
        public bool playerPresent;

        void Update()
        {
            if (Input.GetButtonDown("Fire2") && playerPresent)
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerPresent = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Player not present.");
            if (other.CompareTag("Player"))
            {
                playerPresent = false;
            }
        }
    }
}
