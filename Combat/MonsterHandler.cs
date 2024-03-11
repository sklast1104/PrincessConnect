using System;
using Spine.Unity;
using UnityEngine;

namespace Jun.Combat
{
    public class MonsterHandler : MonoBehaviour
    {
        private SkeletonMecanim _skeletonMecanim;

        private void Start()
        {
            _skeletonMecanim = GetComponent<SkeletonMecanim>();
            _skeletonMecanim.skeleton.SetColor(Color.red);
        }
    }
}


