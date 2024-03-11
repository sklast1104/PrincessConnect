using UnityEngine;

namespace Jun.UI.BattleScene
{
    public class MainUIHandler : MonoBehaviour
    {
        public void EnActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    } 
}


