using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance = null;

    public Node selectNode;

    public NodeBuildUI nodeBuildUI;

    public static BuildManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowBuildWindow(Node _node)
    {
        if (selectNode == _node)
        {
            DeselectNode();
            return;
        }
        
        selectNode = _node;
        
        nodeBuildUI.ShowBuildUI(_node);
    }
    
    public void DeselectNode()
    {
        selectNode = null;
        nodeBuildUI.HideBuildUI();
    }
}