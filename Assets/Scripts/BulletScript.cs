using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public PowerUpSystem powerUpSystem;
    public GameObject Shooter;

    public int bounceCount;

    private void Awake()
    {
        powerUpSystem = GameObject.FindGameObjectWithTag("Player").transform.Find("PowerUpSystem").GetComponent<PowerUpSystem>();
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