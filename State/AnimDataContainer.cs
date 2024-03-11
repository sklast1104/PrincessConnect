using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jun.Stat
{
    public class AnimDataContainer : MonoBehaviour
    {
        [field:SerializeField]
        public List<string> animKeyList { get; private set; }
        
        [field:SerializeField]
        public List<string> animValueList { get; private set; }

        [field:SerializeField]
        public Dictionary<string, string> animMap { get; private set; }

        private void Awake()
        {
            animMap = new Dictionary<string, string>();
        }

        private void Start()
        {
            for (int i = 0; i < animKeyList.Count; i++)
            {
                animMap.Add(animKeyList[i], animValueList[i]);
            }
        }
    }
}


