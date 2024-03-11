using UnityEngine;
using UnityEngine.SceneManagement;
using Jun.Utility;
using Jun.Scene;
using System;

namespace Jun.Manage
{
    public class SceneManagerEx
    {
        public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>();}}

        public Action SceneLoadEvent;
        
        public void LoadScene(Define.Scene type)
        {
            Manager.Clear();
            SceneManager.LoadScene(GetSceneName(type));
            SceneLoadEvent?.Invoke();
        }

        string GetSceneName(Define.Scene type)
        {
            // ReSharper disable once HeapView.BoxingAllocation
            string name = System.Enum.GetName(typeof(Define.Scene), type);
            return name;
        }

        public void Clear()
        {
            if (CurrentScene)
            {
                CurrentScene.Clear();
            }
        }
    }
}


