using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeTay.Pooler;

[System.Serializable]
public class Pool
{
    public string poolName;
    public GameObject prefab;
    public int spawnCount;
    public GameObject Parent;
    public bool canGrow, resetParentOnDestroy;
    private int index = 0;

    public GameObject[] spawnedObjects;

    public void CreateInstances()
    {
        spawnedObjects = new GameObject[spawnCount];

        for (int i = 0; i < spawnCount; i++)
        {
            if (prefab != null)
            {
                if (Parent != null)
                {
                    var instance = Object.Instantiate(prefab, Parent.transform);

                    spawnedObjects[index] = instance;
                    index++;

                    instance.SetActive(false);
                }
                else
                {
                    var instance = Object.Instantiate(prefab);

                    spawnedObjects[index] = instance;
                    index++;

                    instance.SetActive(false);
                }
            }
        }

        Pooler.AddToDictionary(poolName, spawnedObjects);
    }
}
