using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.transform.gameObject);

        GameObject.Destroy(this.transform.gameObject);
    }
}
