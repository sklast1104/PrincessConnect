using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private float maxXsize = 1.21f;
    private float ySize = 0.21f;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //SetHpVal(0.8f);
    }

    public void SetHpVal(float percent)
    {
        float x = percent * maxXsize;
        _spriteRenderer.size = new Vector2(x, ySize);
    }
}
