using System;
using System.Collections;
using UnityEngine;

namespace Jun.Combat
{
    public class DamageEffectHandler : MonoBehaviour
    {
        private GameObject[] numbers = new GameObject[10];
        private GameObject _numPreset;

        [SerializeField]
        private GameObject _char1;
        [SerializeField]
        private GameObject _char2;

        private float _delay = 0.3f;
        
        private void Awake()
        {
            GameObject numParent = transform.parent.GetChild(0).gameObject;
            _numPreset = transform.GetChild(0).gameObject;

            _char1 = _numPreset.transform.GetChild(0).gameObject;
            _char2 = _numPreset.transform.GetChild(1).gameObject;
            
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = numParent.transform.GetChild(i).gameObject;
            }
        }
        
        public void DisplayDamageEffect(int damage)
        {
            int numDigits = Mathf.Max(1, Mathf.FloorToInt(Mathf.Log10(damage) + 1));
            int[] digits = new int[numDigits];
            
            for (int i = numDigits - 1; i >= 0; i--)
            {
                digits[i] = damage % 10;
                damage /= 10;
            }

            for (int i = 0; i < numDigits; i++)
            {
                if (i == 0)
                {
                    _char1.GetComponent<SpriteRenderer>().sprite = numbers[digits[i]].GetComponent<SpriteRenderer>().sprite;
                }else if (i == 1)
                {
                    _char2.GetComponent<SpriteRenderer>().sprite = numbers[digits[i]].GetComponent<SpriteRenderer>().sprite;
                }
            }
            
            _numPreset.SetActive(true);

            // StartCoroutine(AutoDestroyer());
        }

        // IEnumerator AutoDestroyer()
        // {
        //     yield return new WaitForSeconds(0.3f);
        //     
        //     _numPreset.SetActive(false);
        // }
    }
}


