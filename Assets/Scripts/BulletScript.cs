using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public BulletData bulletdata;
    public GameObject Shooter, player;

    public string powerUp;
    public int bounceCount;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletdata = player.transform.Find("Shooter").GetComponent<BulletData>();

        powerUp = bulletdata.powerUp;
        bounceCount = bulletdata.bounceCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (powerUp)
        {
            case "none":

                Debug.Log("Case none");
                GameObject.Destroy(this.transform.gameObject);

                break;

            case "bounce":

                if(bounceCount == 0)
                {
                    GameObject.Destroy(this.transform.gameObject);
                }
                else
                {
                    bounceCount -= 1;
                }

                Debug.Log("Case bounce");

                break;
        }


    }
}
