using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GachaTimeLineHandler : MonoBehaviour
{
    private PlayableDirector timeline;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void StartTimeLine()
    {
        timeline.Play();
    }
}
