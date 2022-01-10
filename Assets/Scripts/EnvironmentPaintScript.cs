using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeTay.Pooler;

public class EnvironmentPaintScript : MonoBehaviour
{
    public float fadeSpeed;
    public Color paintColor;
    [SerializeField] private Color spriteColor;
    private float fadeAmount;

    private void Awake()
    {
        spriteColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void OnEnable()
    {
        spriteColor.a = 1f;
    }

    private void Update()
    {     
        fadeAmount = spriteColor.a - (fadeSpeed * Time.deltaTime);

        spriteColor = new Color(paintColor.r, paintColor.g, paintColor.b, fadeAmount);
        this.GetComponent<SpriteRenderer>().color = spriteColor;

        if (spriteColor.a < 0)
        {
            Pooler.Destroy(gameObject);
        }
    }
}