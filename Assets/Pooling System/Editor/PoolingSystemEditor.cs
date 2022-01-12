using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PoolingSystem))]
public class PoolingSystemEditor : Editor
{
    private GUIStyle AddButton;
    private GUIStyle Name;
    private GUIStyle Label;
    private GUIStyle Horizontal;
    private GUIStyle CountInput;

    private bool initDone = false;

    void initStyles()
    {
        initDone = true;

        AddButton = new GUIStyle(GUI.skin.button)
        {
            fontSize = 20,
        };

        Name = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 20,
        };

        Horizontal = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleLeft,
            fontSize = 15,
        };

        Label = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 15,
        };
    }





    public override void OnInspectorGUI()
    {
        if(!initDone)
        {
            initStyles();
        }


        //base.OnInspectorGUI();

        PoolingSystem poolingSystem = (PoolingSystem)target;

        if (GUILayout.Button("Add Pool", AddButton))
        {
            poolingSystem.AddPool();

            Debug.Log("Add Pool");
        }



        for(int i = 0; i < poolingSystem.pools.Count; i++)
        {
            GUILayout.Space(10);

            Pool pool = poolingSystem.pools[i];

            pool.poolName = EditorGUILayout.TextField(pool.poolName, Name);

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Prefab", Label);

            pool.prefab = (GameObject)EditorGUILayout.ObjectField(pool.prefab, typeof(GameObject), allowSceneObjects: true);

            string path = AssetDatabase.GetAssetPath(pool.prefab);

            EditorGUILayout.LabelField("Parent", Label);

            pool.Parent = (GameObject)EditorGUILayout.ObjectField(pool.Parent, typeof(GameObject), allowSceneObjects: true);

            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Spawn count", Horizontal);

            GUILayout.Space(-100);

            pool.spawnCount = EditorGUILayout.IntField(pool.spawnCount, Horizontal);

            EditorGUILayout.LabelField("Can grow", Horizontal);

            GUILayout.Space(-120);

            pool.canGrow = EditorGUILayout.Toggle(pool.canGrow);

            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("X"))
            {
                poolingSystem.RemovePool(pool);

                Debug.Log("Pool Removed");
            }
        }
    }
}
