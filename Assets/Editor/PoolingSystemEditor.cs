using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PoolingSystem))]
public class PoolingSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PoolingSystem poolingSystem = (PoolingSystem)target;

        if (GUILayout.Button("Add Pool"))
        {
            poolingSystem.AddPool();
            Debug.Log("We pressed Add Pool");
        }
    }
}
