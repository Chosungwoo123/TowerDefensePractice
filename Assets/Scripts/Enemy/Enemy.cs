using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [SerializeField] private Image healthImage;

    [SerializeField] private float barWidth;
    [SerializeField] private GameObject damagedBarTemplate;

    [SerializeField] private Transform canvas;
    
    [SerializeField] private Material hitMat;
    [SerializeField] private Material defaultMat;

    private SpriteRenderer sr;

    private float curHealth;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
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

        StartCoroutine(HitRoutine());

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private IEnumerator HitRoutine()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(0.1f);

        sr.material = defaultMat;
    }
}