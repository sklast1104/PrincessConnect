using UnityEngine;

namespace Jun.Manage
{
    public class ResourceManager
    {
        public T Load<T>(string path) where T : Object
        {
            if (typeof(T) == typeof(GameObject))
            {
                string name = path;
                int index = name.LastIndexOf('/');
                if (index >= 0)
                    name = name.Substring(index + 1);

                GameObject go = Manager.Pool.GetOriginal(name);
                if (go != null)
                    return go as T;
            }
        
            return Resources.Load<T>(path);
        }

        public GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject original = Load<GameObject>($"Prefabs/{path}");
            if (original == null)
            {
                Debug.Log($"Failed to load prefab : {path}");
                return null;
            }

            if (original.GetComponent<Poolable>() != null)
                return Manager.Pool.Pop(original, parent).gameObject;
        
            GameObject go = Object.Instantiate(original, parent);
            go.name = original.name;

            return go;
        }

        public void Destroy(GameObject go)
        {
            if (go == null) return;

            Poolable poolable = go.GetComponent<Poolable>();
            if (poolable != null)
            {
                Manager.Pool.Push(poolable);
                return;
            }
        
            Object.Destroy(go);
        }

        public void DestroyChildren(GameObject parent)
        {
            if (parent == null) return;

            for (int i = parent.transform.childCount - 1; i >= 0; i--)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                Poolable poolable = child.GetComponent<Poolable>();
                if (poolable)
                {
                    Manager.Pool.Push(poolable);
                }
                else
                {
                    Destroy(poolable.gameObject);
                }
            }
        
        }
    }
}


