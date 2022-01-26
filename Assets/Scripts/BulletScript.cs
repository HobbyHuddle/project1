using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public ShooterScript shooterScript;

    private int bounceCount;
    private float maxTimeAlive = 10f;

    private void Awake()
    {
        // FIXME: needs a serious refactor; its not clear at all why the next 2 lines produce a different gameobject with errors than L17.
        GameObject shooter = GameObject.FindGameObjectWithTag("Player").transform.Find("Shooter").gameObject;
        shooterScript = shooter.GetComponent<ShooterScript>();
        shooterScript = FindObjectOfType<ShooterScript>();
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

        GameObject paint = Instantiate(shooterScript.environmentPaintPrefab , pos, rot, shooterScript.environmentPaintParent.transform);

        //Set Scale (Incase of charge)
        paint.transform.localScale = transform.gameObject.transform.localScale;

        //Set Color
        paint.GetComponent<EnvironmentPaintScript>().paintColor = shooterScript.paintColor;

        //Bounce Effect
       if (shooterScript.powerUpSystem.bounce.Active == true)
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


    //Destroy itself after x seconds.
    IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(maxTimeAlive);

        GameObject.Destroy(this.transform.gameObject);
    }
}
