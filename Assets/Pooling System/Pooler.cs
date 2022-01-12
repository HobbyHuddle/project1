using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace DeTay.Pooler
{
    public class Pooler
    {
        public static Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

        public static void AddToDictionary(string name, Pool pool)
        {
            pools.Add(name, pool);
        }


        public static GameObject Instantiate(string name, Vector3 positon, Quaternion rotation)
        {
            GameObject availableGameobject = GetInactive(pools[name].spawnedObjects);

            if (availableGameobject != null)
            {
                
                SetPosition(availableGameobject, positon, rotation);
            }
            else
            {
                if (pools[name].canGrow == true)
                {
                    pools[name].spawnedObjects = ResizeArray(pools[name].spawnedObjects);

                    GameObject newInstance = UnityEngine.Object.Instantiate(pools[name].prefab, positon, rotation);

                    pools[name].spawnedObjects.SetValue(newInstance, pools[name].spawnedObjects.Length - 1);

                    return newInstance;
                }
                else
                {
                    throw new Exception("No inactive Gameobject found! Increase the spawn count of '" + name + "' or mark the pool as 'Can grow'.");
                }   
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
                foreach(Pool pool in pools.Values)
                {
                    if(pool.spawnedObjects.Contains(instance))
                    {
                        instance.transform.parent = pool.Parent.transform;
                    }
                    else
                    {
                        instance.transform.parent = null;
                    }
                }
            }
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

        public static GameObject[] ResizeArray(GameObject[] array)
        {

            int newLength = array.Length + 1;

            GameObject[] temp = new GameObject[newLength];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            array = new GameObject[newLength];

            for (int i = 0; i < newLength; i++)
            {
                array[i] = temp[i];
            }

            return array;
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
