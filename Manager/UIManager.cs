using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jun.Utility;
using Jun.UI;

namespace Jun.Manage
{
    public class UIManager
    {
        private int _order = 10;

        private Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
        private UI_Scene _sceneUI = null;

        public GameObject Root
        {
            get
            {
                GameObject root = GameObject.Find("@UI_Root");
                if (root == null)
                {
                    root = new GameObject();
                    root.name = "@UI_Root";
                }

                return root;
            }
        }

        public void SetCanvas(GameObject go, bool sort = true)
        {
            Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;

            if (sort)
            {
                canvas.sortingOrder = _order;
                _order++;
            }
            else
            {
                canvas.sortingOrder = 0;
            }
        }

        public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate($"UI/SubItem/{name}");

            if (parent != null)
                go.transform.SetParent(parent);

            return Util.GetOrAddComponent<T>(go);
        }

        public T ShowSceneUI<T>(string name = null) where T : UI_Scene
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate($"UI/Scene/{name}");
            T sceneUI = Util.GetOrAddComponent<T>(go);
            _sceneUI = sceneUI;

            go.transform.SetParent(Root.transform);

            return sceneUI;
        }

        public T ShowPopupUI<T>(string name = null) where T : UI_Popup
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;


            // 더 디테일하게 하려면 해당 리소스가 존재하는지 체크하고 들어가야함 
            GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}");

            T popup = Util.GetOrAddComponent<T>(go);
            _popupStack.Push(popup);

            go.transform.SetParent(Root.transform);

            return popup;
        }

        public void ClosePopupUI()
        {
            if (_popupStack.Count == 0)
                return;

            UI_Popup popup = _popupStack.Pop();
            Manager.Resource.Destroy(popup.gameObject);
            popup = null;
            _order--;
        }

        public void ClosePopupUI(UI_Popup popup)
        {
            if (_popupStack.Count == 0)
                return;

            if (_popupStack.Peek() != popup)
            {
                Debug.Log("Close Popup Failed!");
                return;
            }

            ClosePopupUI();
        }

        public void CloseAllPopupUI()
        {
            while (_popupStack.Count > 0)
                ClosePopupUI();
        }

        public void Clear()
        {
            CloseAllPopupUI();
            _sceneUI = null;
        }
    }
}