using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    
    private GameObject target = null;

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;

            transform.position += dir.normalized * (moveSpeed * Time.deltaTime);
            
            float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init(GameObject target)
    {
        this.target = target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Enemy>().OnDamage(damage);
            Destroy(gameObject);
        }
    }
}