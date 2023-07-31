using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathMove : MonoBehaviour
{
    public float moveSpeed;
    
    private Path path;
    
    private Vector2[] curvePoints;
    
    private int movePosIndex = 0;

    private SpriteRenderer sr;
    
    private Vector3 offset;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        offset = new Vector3(0, Random.Range(-1f, 1f), 0);
    }

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        Vector3 nextPos = (Vector3)curvePoints[movePosIndex] - transform.position + offset;
        transform.position += nextPos.normalized * (moveSpeed * Time.deltaTime);

        if (nextPos.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (Vector2.Distance(transform.position - offset, curvePoints[movePosIndex]) <= 0.01f)
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
        
        transform.position = curvePoints[movePosIndex] + (Vector2)offset;

        movePosIndex = 1;
    }
}