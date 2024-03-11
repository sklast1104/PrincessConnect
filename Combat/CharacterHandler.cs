using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public GameObject[] princesses;

    private void Awake()
    {
        princesses = new GameObject[5];

        for (int i = 0; i < 5; i++)
        {
            princesses[i] = transform.GetChild(i).gameObject;
        }
    }

    public void DisablePrincessExceptMe(GameObject me)
    {
        for (int i = 0; i < princesses.Length; i++)
        {
            if (princesses[i] == me) continue;
            princesses[i].SetActive(false);
        }
    }

    public void RestorePrincess()
    {
        for (int i = 0; i < princesses.Length; i++)
        {
            princesses[i].SetActive(true);
        }
    }
}
