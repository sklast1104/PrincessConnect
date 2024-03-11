using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PecoVoiceBtn : MonoBehaviour
{
    public GameObject timelineObj;
    private PlayableDirector _director;

    private Button btn;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        _director = timelineObj.GetComponent<PlayableDirector>();
        
        btn.onClick.AddListener((() =>
        {
            _director.Play();
        }));
    }
}
