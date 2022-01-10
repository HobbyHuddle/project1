using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeTay.Pooler
{
    public class Pooler
    {
        public static Dictionary<string, GameObject[]> pools = new Dictionary<string, GameObject[]>();

        public static Dictionary<GameObject, GameObject> originalParents = new Dictionary<GameObject, GameObject>();

        public static void AddToDictionary(string name, GameObject[] spawnedInstances)
        {
            pools.Add(name, spawnedInstances);
        }

        public static void AddToDictionary(GameObject instance, GameObject parent)
        {
            originalParents.Add(instance, parent);
        }




        public static GameObject Instantiate(string name, Vector3 positon, Quaternion rotation)
        {
            GameObject[] array = pools[name];

            GameObject availableGameobject = GetInactive(array);

            if (availableGameobject != null)
            {
                
                SetPosition(availableGameobject, positon, rotation);
            }
            else
            {
                throw new Exception("No inactive Gameobject found! Increase the spawn count of '"+ name + "' or mark the pool as 'Can grow'.");
            }

            return availableGameobject;

        }

        public static GameObject Instantiate(string name, Vector3 positon, Quaternion rotation, GameObject parent)
        {
            GameObject availableGameobject = Instantiate(name, positon, rotation);

            availableGameobject.transform.parent = parent.transform;

            return availableGameobject;
        }




        public static void Destroy(GameObject instance)
        {
            instance.SetActive(false);
        }

        public static void Destroy(GameObject instance, bool resetParent)
        {
            Destroy(instance);

            if (resetParent == true)
            {
                if (originalParents.ContainsKey(instance))
                {
                    GameObject parent = originalParents[instance];

                    instance.transform.parent = parent.transform;
                }
                else
                {
                    instance.transform.parent = null;
                }
            }
        }


        private static bool HasInactive(GameObject[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i].activeSelf == false)
                {
                    return true;
                }
            }
            return false;
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
            return null;
        }

        public static void SetPosition(GameObject g, Vector3 positon, Quaternion rotation)
        {
            if(g == null)
            {
                return;
            }

            g.transform.position = positon;
            g.transform.rotation = rotation;
            g.SetActive(true);
        }
    }
}
