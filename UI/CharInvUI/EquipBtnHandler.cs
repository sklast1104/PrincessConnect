using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipBtnHandler : MonoBehaviour
{
    public GameObject equipBtn;
    public GameObject unequipBtn;

    private Button btn;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener((() =>
        {
            equipBtn.gameObject.SetActive(true);
            unequipBtn.gameObject.SetActive(false);
        }));
    }
}
