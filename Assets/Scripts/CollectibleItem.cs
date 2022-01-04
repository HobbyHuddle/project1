using Data;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public ItemData item;
    public BoxCollider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // TODO: add item to players inventory
            Destroy(gameObject);
        }
    }
}
