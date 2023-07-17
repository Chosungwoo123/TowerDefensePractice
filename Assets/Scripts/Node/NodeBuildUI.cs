using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NodeBuildUI : MonoBehaviour
{
    public Button[] buildButtons;
    
    public Vector2[] buildButtonsPos;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        buildButtonsPos = new Vector2[buildButtons.Length];
        
        for(int i = 0; i < buildButtonsPos.Length; i++)
        {
            buildButtonsPos[i] = buildButtons[i].GetComponent<RectTransform>().anchoredPosition;
            buildButtons[i].gameObject.SetActive(false);
        }

        _waitForSeconds = new WaitForSeconds(0.3f);
    }

    public void ShowBuildUI(Node node)
    {
        transform.position = node.transform.position; 
        
        for (int i = 0; i < buildButtons.Length; i++)
        {
            buildButtons[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            buildButtons[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < buildButtons.Length; i++)
        {
            buildButtons[i].GetComponent<RectTransform>().DOAnchorPos(buildButtonsPos[i], 0.3f);
        }
    }
    
    public void HideBuildUI()
    {
        for (int i = 0; i < buildButtons.Length; i++)
        {
            buildButtons[i].GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.3f);
        }

        StartCoroutine(DisableButton());
    }
    
    IEnumerator DisableButton()
    {
        yield return _waitForSeconds;
        
        for (int i = 0; i < buildButtons.Length; i++)
        {
            buildButtons[i].gameObject.SetActive(false);
        }
    }
}