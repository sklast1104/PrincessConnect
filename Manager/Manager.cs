using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Jun.Manage
{
    public class Manager : MonoBehaviour
    {
        private static Manager s_instance;

        public static Manager Instance
        {
            get { Init();
                return s_instance;
            }
        }

        private PoolManager _pool = new PoolManager();
        private ResourceManager _resource = new ResourceManager();
        private SceneManagerEx _scene = new SceneManagerEx();
        private SoundManager _sound = new SoundManager();
        private UIManager _ui = new UIManager();
        
        public static PoolManager Pool { get { return Instance._pool; } }
        public static ResourceManager Resource { get { return Instance._resource; } }
        public static SceneManagerEx Scene {  get { return Instance._scene; } }
        public static SoundManager Sound { get { return Instance._sound;}}
        public static UIManager UI { get {return Instance._ui;}}
        
        private void Start()
        {
            Init();
        }

        private static void Init()
        {
            if (s_instance == null)
            {
                GameObject go = GameObject.Find("GameManager");
                if (go == null)
                {
                    go = new GameObject();
                    go.name = "GameManager";
                    go.AddComponent<Manager>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Manager>();
                
                s_instance._pool.Init();
                s_instance._sound.Init();
            }
        }

        public static void Clear()
        {
            Sound.Clear();
            Scene.Clear();
            UI.Clear();
        
            Pool.Clear();
        }
    }
}


