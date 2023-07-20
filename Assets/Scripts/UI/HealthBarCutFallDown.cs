using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBarCutFallDown : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    [SerializeField] private float fallDownTime;
    [SerializeField] private float fadeTime;

    private RectTransform rect;
    private Image image;
    private Color color;

    private void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        image = transform.GetComponent<Image>();
        color = image.color;
    }

    private void Update()
    {
        fallDownTime -= Time.deltaTime;

        if (fallDownTime < 0)
        {
            rect.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;

            fadeTime -= Time.deltaTime;

            if (fadeTime < 0)
            {
                float alphaFadeSpeed = 5f;

                color.a -= alphaFadeSpeed * Time.deltaTime;

                image.color = color;

                if (color.a <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}