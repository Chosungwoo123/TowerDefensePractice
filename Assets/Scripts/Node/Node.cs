using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color overColor;
    public Color nomalColor;
    
    private GameObject tower;
    
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

        if (tower != null)
        {
            // 업그레이드 UI
            
            BuildManager.Instance.HideBuildUI();
            
            BuildManager.Instance.ShowUpgradeWindow(this);
            
            return;
        }
        
        BuildManager.Instance.HideUpgradeUI();
        
        BuildManager.Instance.ShowBuildWindow(this);
    }

    public void BuildTower(GameObject towerPrefab)
    {
        tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);

        var srColor = sr.color;
        srColor.a = 0;
    }
    
    public void DestoryTower()
    {
        Destroy(tower);
        tower = null;
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