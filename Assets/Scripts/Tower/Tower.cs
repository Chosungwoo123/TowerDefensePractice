using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float scanRange;
    [SerializeField] private float fireRate;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private LayerMask targetLayer;

    private float fireTimer;
    
    private GameObject nearestTarget;

    private RaycastHit2D[] targets;

    private void Start()
    {
        fireTimer = fireRate;
    }

    private void Update()
    {
        FireUpdate();
    }

    private void FixedUpdate()
    {
        CheckNearestTarget();
    }
    
    private void FireUpdate()
    {
        if (fireTimer <= 0 && nearestTarget != null)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            bullet.GetComponent<Bullet>().Init(nearestTarget);

            fireTimer = fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    private void CheckNearestTarget()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

        float dst = 100f;

        GameObject temp = null;

        if (targets != null)
        {
            foreach (var item in targets)
            {
                float curDst = Vector3.Distance(transform.position, item.transform.position);

                if (curDst < dst)
                {
                    dst = curDst;
                    temp = item.transform.gameObject;
                }
            }
        }

        nearestTarget = temp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, scanRange);
    }
}