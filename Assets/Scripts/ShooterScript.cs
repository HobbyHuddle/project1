using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public PowerUpSystem powerUpSystem;

    private Vector2 dirToMouse, bubbleSize;
    [SerializeField] private GameObject bulletPrefab, bulletsParent, bulletSpawnPoint, gun;
    public GameObject environmentPaintPrefab, environmentPaintParent;
    private int bulletCollideLayer;
    [SerializeField] private float projectileSpeed, cooldown;
    private bool cooldownRunning, chargeUpRunning;
    public Color paintColor;

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
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldownRunning == false)
            {
                PowerUpOnShot();
            }
        }
    }


    //This will calculate many different PowerUps which apply BEFORE the bullet is fired. As of right now, its only the charge effect.
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
        }
    }


    //Stardard Shot function. Spawns the bullet and shot it in the aimed direction.
    private void Shoot()
    {
        StartCoroutine(Cooldown());

        GameObject clone = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation, bulletsParent.transform);

        clone.GetComponent<SpriteRenderer>().color = paintColor;

        var rb2D = clone.gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(clone.transform.right * projectileSpeed);

        clone.transform.localScale = bubbleSize;
        bubbleSize = new Vector2(0.3f, 0.3f);
    }


    //Cooldown coroutine. Takes the coolddown variable to wait in seconds.
    IEnumerator Cooldown()
    {
        cooldownRunning = true;
        yield return new WaitForSeconds(cooldown);
        cooldownRunning = false;
        yield break;
    }


    //ChargeUp mechanic. it changes the bubblesize the longer you hold down the mouseButton.
    IEnumerator ChargeUp()
    {
        chargeUpRunning = true;

        while(true)

            if(Input.GetKey(KeyCode.Mouse0))
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
                    yield return null;
                }
            }
            else
            {
                Shoot();
                chargeUpRunning = false;
                yield break;
            }
    }


}