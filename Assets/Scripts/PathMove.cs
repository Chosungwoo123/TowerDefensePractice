using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public float moveSpeed;
    
    public Path path;
    
    private Vector3[] curvePoints;

    private int moveIndex = 0;
    private int movePosIndex = 0;

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        if (movePosIndex == curvePoints.Length)
        {
            CalculateCurvePoints(50);
            
            transform.position = curvePoints[0];

            movePosIndex = 1;
        }

        Vector3 nextPos = curvePoints[movePosIndex] - transform.position;
        transform.position += nextPos.normalized * (moveSpeed * Time.deltaTime);

        float angle = Mathf.Atan2(nextPos.normalized.y, nextPos.normalized.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Vector2.Distance(transform.position, curvePoints[movePosIndex]) <= 0.1f)
        {
            movePosIndex++;
        }
    }

    private void CalculateCurvePoints(int count)
    {
        if (moveIndex >= path.NumSegments)
        {
            Destroy(gameObject);
            
            moveIndex = 0;
        }
        
        Vector2[] temp = path.GetPointsInSegment(moveIndex);

        Vector2 pA = temp[0];
        Vector2 pB = temp[1];
        Vector2 pC = temp[2];
        Vector2 pD = temp[3];
        
        curvePoints = new Vector3[count + 1];
        
        float unit = 1.0f / count;

        int i = 0; float t = 0f;
        
        for (; i < count + 1; i++, t += unit)
        {
            float t2 = t * t;
            float t3 = t * t2;
            float u = (1 - t);
            float u2 = u * u;
            float u3 = u * u2;

            curvePoints[i] =
                pA * u3 +
                pB * (t  * u2 * 3) +
                pC * (t2 * u  * 3) +
                pD * t3;
        }

        moveIndex++;
    }

    public void Init(Path path)
    {
        this.path = path;
        
        CalculateCurvePoints(50);

        transform.position = curvePoints[movePosIndex];

        movePosIndex = 1;
    }
}