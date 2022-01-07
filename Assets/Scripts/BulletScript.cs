using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeTay.Pooler;

public class BulletScript : MonoBehaviour
{
    public ShooterScript shooterScript;

    private int bounceCount;
    private float maxTimeAlive = 10f;

    private void Awake()
    {
        GameObject shooter = GameObject.FindGameObjectWithTag("Player").transform.Find("Shooter").gameObject;
        shooterScript = shooter.GetComponent<ShooterScript>();
    }

    private void Start()
    {
        bounceCount = shooterScript.powerUpSystem.bounce.BounceCount;
        StartCoroutine(TimeDeath());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CollisionData
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Random.rotation;
        rot.x = 0;
        rot.y = 0;
        Vector2 pos = contact.point;

        GameObject paint = Pooler.Instantiate("Paint", pos, rot);

        //Set Scale (Incase of charge)
        paint.transform.localScale = transform.gameObject.transform.localScale;

        //Set Color
        paint.GetComponent<EnvironmentPaintScript>().paintColor = shooterScript.paintColor;

        //Bounce Effect
       if (shooterScript.powerUpSystem.bounce.Active == true)
        {
            if (bounceCount == 0)
            {
                Pooler.Destroy(gameObject);
            }
            else
            {
               bounceCount -= 1;
            }
        }
        else
        {
            Pooler.Destroy(gameObject);
        }
    }


    //Destroy itself after x seconds.
    IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(maxTimeAlive);

        Pooler.Destroy(gameObject);
    }
}