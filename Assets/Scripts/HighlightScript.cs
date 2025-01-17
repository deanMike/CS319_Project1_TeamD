﻿using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour
{

    private Color[] startColors;
    private Color highlightColor = new Color(1f, 1f, 1f, 0.3f);
    private Material[] materialArray;
    private bool highlight = true;
    private VariableControl variables;

    void Awake()
    {
        if (GameObject.Find("VariableController").GetComponent<VariableControl>())
        variables = GameObject.Find("VariableController").GetComponent<VariableControl>();
    }

    void OnMouseEnter()
    {
        if (highlight && !variables.interacting)
        {
            materialArray = GetComponent<Renderer>().materials;
            
            startColors = new Color[materialArray.Length];

            for (int i = 0; i < materialArray.Length; i++)
            {
                startColors[i] = materialArray[i].color;
                materialArray[i].color = highlightColor;
            }
        }
    }

    void OnMouseExit()
    {
        for (int i = 0; i < materialArray.Length; i++)
        {
            materialArray[i].color = startColors[i];
        }
    }


}