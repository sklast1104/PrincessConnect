using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HiyoriVideoPlayer : MonoBehaviour
{
    private VideoPlayer _player;
    public VideoClip _secondClip;

    public GameObject hiyoriContainer;
    private GachaCardResult _result;
    private GachaNextBtnCanvas _btnCanvas;

    private GachaSpecialBtnCanvas _specialBtnCanvas;

    private void Awake()
    {
        _player = GetComponent<VideoPlayer>();
        _result = FindObjectOfType<GachaCardResult>(true);
        _btnCanvas = FindObjectOfType<GachaNextBtnCanvas>(true);
        _specialBtnCanvas = FindObjectOfType<GachaSpecialBtnCanvas>(true);
    }

    private void OnEnable()
    {
        _player.loopPointReached += OnVideoFinished;
    }

    private void OnDisable()
    {
        _player.loopPointReached -= OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer source)
    {
        source.clip = _secondClip;
        hiyoriContainer.SetActive(true);
        
        _result.gameObject.SetActive(false);
        _btnCanvas.gameObject.SetActive(false);
        
        _specialBtnCanvas.gameObject.SetActive(true);
    }
}
