using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Jun.Utility
{
    public class PostProcessManager : MonoBehaviour
    {
        private Volume _volume;
        private DepthOfField _dof;

        private void Awake()
        {
            _volume = GetComponent<Volume>();
            _volume.profile.TryGet(out _dof);
        }

        public void EnableDof(bool flag)
        {
            _dof.active = flag;
        }
    }
}