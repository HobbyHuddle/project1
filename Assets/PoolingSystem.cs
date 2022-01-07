using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    [SerializeField] public List<Pool> pools = new List<Pool>();

    private void Awake()
    {
        foreach(var pool in pools)
        {
            pool.CreateInstances();
        }
    }

    public void AddPool()
    {
        pools.Add(new Pool());
    }

}
