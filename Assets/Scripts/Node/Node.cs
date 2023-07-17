using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color overColor;
    public Color nomalColor;

    public GameObject turret;
    
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        BuildManager.Instance.ShowBuildWindow(this);
    }

    private void OnMouseEnter()
    {
        sr.color = overColor;
    }

    private void OnMouseExit()
    {
        sr.color = nomalColor;
    }
}