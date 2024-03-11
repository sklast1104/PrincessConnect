using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotHandler : MonoBehaviour
{
    public GameObject[] btns = new GameObject[6];
    public GameObject[] effects = new GameObject[6];
    
    private void OnFrameClick(int index)
    {
        for (int i = 0; i < 6; i++)
        {
            effects[i].SetActive(false);
        }
        
        Debug.Log(index);
        
        effects[index].SetActive(true);
    }
    
    private void Awake()
    {

        for (int i = 0; i < 6; i++)
        {
            btns[i].GetComponent<Button>().onClick.AddListener(() => OnFrameClick(i));
        }
    }
}
