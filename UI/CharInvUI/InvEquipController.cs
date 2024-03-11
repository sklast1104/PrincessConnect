using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvEquipController : MonoBehaviour
{
    private Image image;
    public GameObject childText;

    private TextMeshProUGUI childTex;

    private void Awake()
    {
        image = GetComponent<Image>();
        childTex = childText.GetComponent<TextMeshProUGUI>();
    }

    public void DisableBtn()
    {
        image.color = new Color(0.6f, 0.6f, 0.6f);
        childTex.color = new Color(0.6f, 0.6f, 0.6f);
    }

    public void EnableBtn()
    {
        image.color = Color.white;
        childTex.color = Color.white;
    }
}
