using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeTay.Pooler;

public class Pool : MonoBehaviour
{
    public string poolName;
    public GameObject prefab, Parent;
    public int spawnCount;
    private int index = 0;

    public GameObject[] spawnedObjects;


    private void Awake()
    {
        spawnedObjects = new GameObject[spawnCount];

        for (int i = 0; i < spawnCount; i++)
        {
            if (prefab != null)
            {
                if (Parent != null)
                {
                    var instance = Instantiate(prefab, Parent.transform);

                    spawnedObjects[index] = instance;
                    index++;

                    instance.SetActive(false);
                }
                else
                {
                    var instance = Instantiate(prefab);

                    spawnedObjects[index] = instance;
                    index++;

                    instance.SetActive(false);
                }
            }
        }

        Pooler.AddToDictionary(poolName, spawnedObjects);
    }
}
