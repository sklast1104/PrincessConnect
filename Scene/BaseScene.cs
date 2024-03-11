using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;
using Jun.Utility;
using Jun.Manage;

namespace Jun.Scene
{
    public abstract class BaseScene : MonoBehaviour
    {
        private Define.Scene sceneType;
    
        public Define.Scene SceneType { get; protected set; }
    
        protected virtual void Init()
        {

            Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
            if (obj == null)
                Manager.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }

        public abstract void Clear();
    }
}


