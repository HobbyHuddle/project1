using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private Vector2 dirToMouse, raycast2DEndPoint, raycast2DHitPoint;
    [SerializeField] private GameObject raycast2DHitObject, bulletPrefab, bulletSpawnPoint, gun, player;
    [SerializeField] private int bulletCollideLayer;
    [SerializeField] private float projectileSpeed;
    public float raycastDistance = 5f;


    private void Start()
    {
        bulletCollideLayer = LayerMask.GetMask("Platform");
    }

    private void Update()
    {
        //Rotate gun towards Mouse
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        dirToMouse = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Left-Click To Shoot
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, gun.transform.right, raycastDistance, bulletCollideLayer);
        raycast2DEndPoint = new Vector2(gun.transform.position.x, gun.transform.position.y) + (dirToMouse.normalized * raycastDistance);
        
        if (hit.collider != null)
        {
            Debug.Log("Did Hit " + raycast2DHitObject);
            Debug.DrawLine(bulletSpawnPoint.transform.position, hit.point, Color.green, 2);
            raycast2DHitObject = hit.collider.transform.gameObject;
            raycast2DHitPoint = hit.point;
        }
        else
        {
            Debug.Log("Did NOT Hit!");
            Debug.DrawLine(bulletSpawnPoint.transform.position, raycast2DEndPoint, Color.red, 2);
        }


        GameObject clone = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        var rb2D = clone.gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(clone.transform.right * projectileSpeed);
    }
}