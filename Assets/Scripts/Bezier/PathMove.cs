using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public float moveSpeed;
    
    private Path path;
    
    private Vector2[] curvePoints;
    
    private int movePosIndex = 0;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        Vector3 nextPos = (Vector3)curvePoints[movePosIndex] - transform.position;
        transform.position += nextPos.normalized * (moveSpeed * Time.deltaTime);

        if (nextPos.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (Vector2.Distance(transform.position, curvePoints[movePosIndex]) <= 0.01f)
        {
            movePosIndex++;
        }

        if (movePosIndex >= curvePoints.Length)
        {
            Destroy(gameObject);
        }
    }

    public void Init(Path path)
    {
        this.path = path;

        curvePoints = path.CalculateEvenlySpacedPoints(0.1f);
        
        transform.position = curvePoints[movePosIndex];

        movePosIndex = 1;
    }
}