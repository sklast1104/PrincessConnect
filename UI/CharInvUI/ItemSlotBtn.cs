using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotBtn : MonoBehaviour
{
    public GameObject[] effects = new GameObject[6];
    public int index;

    public Sprite icon;
    public string title1Name;
    public string title2Name;
    public string title3Name;

    public string firstVal;
    public string secondVal;

    public int count;
    
    private Button btn;
    
    // for Right Container
    private Image itemImage;
    private GameObject invItemName;
    private GameObject invFirstName;
    private GameObject invLastName;

    private GameObject invFirstVal;
    private GameObject invLastVal;

    private GameObject rightInvCount;

    private string count1 = "x1";
    private string count0 = "x0";

    private InvEquipController _equipController;
    
    private void Awake()
    {
        itemImage = FindObjectOfType<InvRightItemSprite>(true).GetComponent<Image>();
        invItemName = FindObjectOfType<InvItemName>(true).gameObject;

        invFirstName = FindObjectOfType<InvFirstString>(true).gameObject;
        invLastName = FindObjectOfType<InvSecondString>(true).gameObject;

        invFirstVal = FindObjectOfType<InvFirstVal>(true).gameObject;
        invLastVal = FindObjectOfType<InvLastVal>(true).gameObject;

        rightInvCount = FindObjectOfType<RightInvCount>(true).gameObject;
        
        btn = GetComponent<Button>();
        _equipController = FindObjectOfType<InvEquipController>(true);
        
        
        btn.onClick.AddListener((() =>
        {
            for (int i = 0; i < 6; i++)
            {
                effects[i].gameObject.SetActive(false);
                
            }
            
            effects[index].gameObject.SetActive(true);
            
            itemImage.sprite = icon;
            invItemName.GetComponent<TextMeshProUGUI>().text = title1Name;
            invFirstName.GetComponent<TextMeshProUGUI>().text = title2Name;
            invLastName.GetComponent<TextMeshProUGUI>().text = title3Name;

            invFirstVal.GetComponent<TextMeshProUGUI>().text = firstVal;
            invLastVal.GetComponent<TextMeshProUGUI>().text = secondVal;

            //rig
            if (count == 0)
            {
                rightInvCount.GetComponent<TextMeshProUGUI>().text = count0;
                _equipController.DisableBtn();
            }
            else
            {
                rightInvCount.GetComponent<TextMeshProUGUI>().text = count1;
                _equipController.EnableBtn();
            }
        }));
    }
}
