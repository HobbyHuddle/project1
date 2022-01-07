using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace DeTay.Pooler
{
    public class Pooler
    {
        public static Dictionary<string, GameObject[]> pools = new Dictionary<string, GameObject[]>();

        public static void AddToDictionary(string name, GameObject[] spawnedInstances)
        {
            pools.Add(name, spawnedInstances);
        }




        public static GameObject Instantiate(string name, Vector3 positon, Quaternion rotation)
        {
            GameObject[] array = pools[name];

            GameObject availableGameobject = GetInactive(array);

            SetPosition(availableGameobject, positon, rotation);

            return availableGameobject;
        }

        public static GameObject Instantiate(string name, Vector3 positon, Quaternion rotation, GameObject parent)
        {
            GameObject[] array = pools[name];

            GameObject availableGameobject = GetInactive(array);

            SetPosition(availableGameobject, positon, rotation);

            availableGameobject.transform.parent = parent.transform;

            return availableGameobject;
        }




        public static void Destroy(GameObject instance)
        {
            instance.SetActive(false);
        }





        private static GameObject GetInactive(GameObject[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i].activeSelf == false)
                {
                    return g[i];
                }
            }
            Debug.Log("No available Pooled Item");
            return null;
        }

        public static void SetPosition(GameObject g, Vector3 positon, Quaternion rotation)
        {
            g.transform.position = positon;
            g.transform.rotation = rotation;
            g.SetActive(true);
        }
    }
}
