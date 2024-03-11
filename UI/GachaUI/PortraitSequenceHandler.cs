using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitSequenceHandler : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DelayedActive());
    }

    private void Start()
    {
        
    }

    IEnumerator DelayedActive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            
            yield return new WaitForSeconds(0.1f);
            
           child.SetActive(true);
        }
    }
}
