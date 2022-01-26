using UnityEngine;

namespace World
{
    public class Spawner : MonoBehaviour
    {
        public Transform characterPrefab;

        public void Spawn()
        {
            Instantiate(characterPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
