using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PecoSkinSigChanger : MonoBehaviour
{
    public GameObject skelObj;

    private SkeletonAnimation anim;

    private void Awake()
    {
        anim = skelObj.GetComponent<SkeletonAnimation>();
    }

    public void ChangeJoySkin()
    {
        anim.skeleton.SetSkin("joy");
    }

    public void ChangeIdleSkin()
    {
        anim.skeleton.SetSkin("normal");
    }

    public void ChangeShySkin()
    {
        anim.skeleton.SetSkin("shy");
    }
}
