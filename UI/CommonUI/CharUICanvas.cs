using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

public class CharUICanvas : MonoBehaviour
{
    private void OnEnable()
    {
        Manager.Sound.Play(Define.Sound.Bgm, "Char_Main");
    }
}
