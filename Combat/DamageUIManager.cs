using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jun.Combat
{
    public class DamageUIManager : MonoBehaviour
    {
        private GameObject[] damages = new GameObject[5];

        private void Awake()
        {
            for (int i = 0; i < 5; i++)
            {
                damages[i] = transform.GetChild(1 + i).gameObject;
            }
        }

        public void DamageEffect(int damage)
        {
            for (int i = 0; i < 5; i++)
            {
                if (damages[i].activeSelf)
                {
                    continue;
                }
                else
                {
                    damages[i].SetActive(true);
                    damages[i].GetComponent<DamageEffectHandler>().DisplayDamageEffect(damage);
                    StartCoroutine(AutoDestroyer(damages[i]));
                    return;
                }
            }
        }

        IEnumerator AutoDestroyer(GameObject go)
        {
            yield return new WaitForSeconds(0.5f);
            
            go.SetActive(false);
        }
    } 
}


