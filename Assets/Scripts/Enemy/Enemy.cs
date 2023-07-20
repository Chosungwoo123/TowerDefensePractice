using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [SerializeField] private Image healthImage;

    [SerializeField] private float barWidth;
    [SerializeField] private GameObject damagedBarTemplate;

    [SerializeField] private Transform canvas;

    private float curHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void OnDamage(float damage)
    {
        float beforeDamageBarFillAmount = healthImage.fillAmount;

        GameObject damagedBar = Instantiate(damagedBarTemplate, canvas.transform);

        damagedBar.SetActive(true);
        
        curHealth -= damage;

        healthImage.fillAmount = curHealth / maxHealth;

        damagedBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(healthImage.fillAmount * barWidth,
            healthImage.GetComponent<RectTransform>().anchoredPosition.y);

        damagedBar.GetComponent<Image>().fillAmount = beforeDamageBarFillAmount - healthImage.fillAmount;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}