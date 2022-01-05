using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPaintScript : MonoBehaviour
{
    public float fadeSpeed;
    public Color paintColor;

    private void Update()
    {
        Color spriteColor = this.GetComponent<SpriteRenderer>().material.color;
        float fadeAmount = spriteColor.a - (fadeSpeed * Time.deltaTime);

        spriteColor = new Color(paintColor.r, paintColor.g, paintColor.b, fadeAmount);
        this.GetComponent<SpriteRenderer>().material.color = spriteColor;

        if (spriteColor.a < 0.01f)
        {
            GameObject.Destroy(this.transform.gameObject);
        }
    }
}
