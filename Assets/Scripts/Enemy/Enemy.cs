using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [SerializeField] private Image healthImage;

    private float curHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }

    private void Update()
    {
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, curHealth / maxHealth, Time.deltaTime * 4);
    }

    public void OnDamage(float damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}