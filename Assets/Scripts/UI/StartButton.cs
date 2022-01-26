using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartButton : MonoBehaviour
    {
        public string sceneName;
        public int sceneNumber;
    
        public void LoadScene()
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
