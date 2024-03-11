using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jun.UI.GachaUI
{
    public class GachaSequenceEffect : MonoBehaviour
    {
        private List<GameObject> cards;
        
        private void Awake()
        {
            cards = new List<GameObject>();

            for (int i = 0; i < transform.childCount; i++)
            {
                cards.Add(transform.GetChild(i).gameObject);
            }
        }

        private void Start()
        {
            StartCoroutine(CardEffectPlayer());
        }

        IEnumerator CardEffectPlayer()
        {
            yield return new WaitForSeconds(1f);
            
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].SetActive(true);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}


