using Jun.Manage;
using UnityEngine;

namespace Jun.UI.Common
{
    public class FaderCanvasController : MonoBehaviour
    {
        private Canvas _canvas;
        
        void Start()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            Debug.Log(GameObject.FindWithTag("MainCamera"));
        }
    }
}


