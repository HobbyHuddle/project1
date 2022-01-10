using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PoolingSystem))]
public class PoolingSystemEditor : Editor
{
    protected static bool showAdvanced = false;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PoolingSystem poolingSystem = (PoolingSystem)target;

        if (GUILayout.Button("Add Pool"))
        {
            poolingSystem.AddPool();
            Debug.Log("Add Pool");
        }

        for(int i = 0; i < poolingSystem.pools.Count; i++)
        {
            Pool pool = poolingSystem.pools[i];

            GUILayout.BeginHorizontal();

            pool.poolName = EditorGUILayout.TextField("Name of Pool", pool.poolName);

            pool.spawnCount = EditorGUILayout.IntField("Spawn count", pool.spawnCount);

            GUILayout.EndHorizontal();

            pool.prefab = (GameObject)EditorGUILayout.ObjectField(pool.prefab, typeof(GameObject), allowSceneObjects: true);

            pool.Parent = (GameObject)EditorGUILayout.ObjectField(pool.Parent, typeof(GameObject), allowSceneObjects: true);

            pool.canGrow = EditorGUILayout.Toggle("Can grow", pool.canGrow);

            if (GUILayout.Button("X"))
            {
                poolingSystem.RemovePool(pool);
                Debug.Log("Pool Removed");
            }

        }
    }
}
