using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    PowerUpSystem powerUpSystem;

    private Vector2 dirToMouse, raycast2DEndPoint, raycast2DHitPoint, bubbleSize;
    [SerializeField] private GameObject raycast2DHitObject, bulletPrefab, bulletsParent, bulletSpawnPoint, gun;
    public GameObject environmentPaintPrefab, environmentPaintParent;
    private int bulletCollideLayer;
    [SerializeField] private float projectileSpeed, cooldown;
    private float raycastDistance = 25;
    [SerializeField] private bool cooldownRunning, chargeUpRunning, mouseButtonDown;
    public Color paintColor;

    private void Awake()
    {
        powerUpSystem = GameObject.FindGameObjectWithTag("Player").transform.Find("PowerUpSystem").GetComponent<PowerUpSystem>();
    }

    private void Start()
    {
        bulletCollideLayer = LayerMask.GetMask("Platform");

        bubbleSize = new Vector2(0.3f, 0.3f);
    }

    private void Update()
    {
        //Rotate gun towards Mouse
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        dirToMouse = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //Left-Click To Shoot
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouseButtonDown = true;
        }
        else
        {
            mouseButtonDown = false;
        }
        if(mouseButtonDown)
        {
            if (cooldownRunning == false)
            {
                PowerUpOnShot();
            }
        }
    }


    private void PowerUpOnShot()
    {
        if(powerUpSystem.charge.Active == false)
        {
            Shoot();
        }
        else
        {
            if(chargeUpRunning == false)
            {
                StartCoroutine(ChargeUp());
            }

            if(mouseButtonDown == false)
            {
                StopCoroutine(ChargeUp());
                Shoot();
                bubbleSize = new Vector2(0.3f, 0.3f);
                chargeUpRunning = false;
            }
        }
    }

    private void Shoot()
    {
        StartCoroutine(Cooldown());

        RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, gun.transform.right, raycastDistance, bulletCollideLayer);
        raycast2DEndPoint = new Vector2(gun.transform.position.x, gun.transform.position.y) + (dirToMouse.normalized * raycastDistance);

        if (hit.collider != null)
        {
            Debug.DrawLine(bulletSpawnPoint.transform.position, hit.point, Color.green, 2);
            raycast2DHitObject = hit.collider.transform.gameObject;
            raycast2DHitPoint = hit.point;
        }
        else
        {
            Debug.Log("Raycast did not hit any object! is there a gap in the level borders?");
            Debug.DrawLine(bulletSpawnPoint.transform.position, raycast2DEndPoint, Color.red, 2);
        }


        GameObject clone = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation, bulletsParent.transform);

        var rb2D = clone.gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(clone.transform.right * projectileSpeed);

        clone.transform.localScale = bubbleSize;
    }

    IEnumerator Cooldown()
    {
        cooldownRunning = true;
        yield return new WaitForSeconds(cooldown);
        cooldownRunning = false;
        yield break;
    }

    IEnumerator ChargeUp()
    {
        chargeUpRunning = true;

        while(true)

            if(mouseButtonDown == true)
            {
                if(powerUpSystem.charge.MaxChargeSize.x > bubbleSize.x)
                {
                    bubbleSize.x += powerUpSystem.charge.ChargeRatePerSecond * 0.1f;
                    bubbleSize.y += powerUpSystem.charge.ChargeRatePerSecond * 0.1f;
                    yield return new WaitForSeconds(0.1f);
                }

                else
                {
                    Debug.Log("Max chargeSize reached");
                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                Shoot();
                bubbleSize = new Vector2(0.3f, 0.3f);
                chargeUpRunning = false;
                yield break;
            }
    }


}