using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.QuestMapUI
{
    public class QuestMapUIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Bgm, "Map_Theme");
        }
    }
}


