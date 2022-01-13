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
            if (Input.GetKeyDown(KeyCode.J) && playerPresent)
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerPresent = true;
            }
            else
            {
                playerPresent = false;
            }
        }
    }
}
