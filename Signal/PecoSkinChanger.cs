using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PecoSkinChanger : MonoBehaviour
{
    public GameObject spineObj;
    private SkeletonAnimation anim;
    
    private void Awake()
    {
        anim = spineObj.GetComponent<SkeletonAnimation>();
        
        
    }

    public void ChangeJoySkin()
    {
        anim.Skeleton.SetSkin("joy");
    }
}
