using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.GachaUI
{
    public class GachaUIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Bgm, "Gacha_main_Theme");
        }
    }
}