using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public PowerUpSystem powerUpSystem;
    public ShooterScript shooterScript;

    public int bounceCount;

    private void Awake()
    {
        powerUpSystem = GameObject.FindGameObjectWithTag("Player").transform.Find("PowerUpSystem").GetComponent<PowerUpSystem>();
        shooterScript = GameObject.FindGameObjectWithTag("Player").transform.Find("Shooter").GetComponent<ShooterScript>();
    }

    private void Start()
    {
        bounceCount = powerUpSystem.bounce.BounceCount;
    }


    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Random.rotation;
        rot.x = 0;
        rot.y = 0;
        Vector2 pos = contact.point;

        GameObject paint = Instantiate(shooterScript.environmentPaintPrefab , pos, rot, shooterScript.environmentPaintParent.transform);
        paint.GetComponent<EnvironmentPaintScript>().paintColor = shooterScript.paintColor;

       if (powerUpSystem.bounce.Active == true)
        {
            if (bounceCount == 0)
            {
                GameObject.Destroy(this.transform.gameObject);
            }
            else
            {
               bounceCount -= 1;
            }
        }
        else
        {
            GameObject.Destroy(this.transform.gameObject);
        }
    }
}
