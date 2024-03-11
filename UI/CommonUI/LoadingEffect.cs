using System.Collections;
using UnityEngine;

namespace Jun.UI.Common
{
    public class LoadingEffect : MonoBehaviour
    {
        Transform[] loadingChars;
        private Vector2 upVec = new Vector2(0, 20);

        private void Awake()
        {
            loadingChars = GetComponentsInChildren<Transform>(true);
        }

        public void StartEffect()
        {
            StartCoroutine(LoadingEffectCor());
        }
        
        IEnumerator LoadingEffectCor()
        {
            // 여기서 캐릭터들 원위치 시키는 로직 해줘야 될 수도 있음

            for (int j = 0; j < 2; j++)
            {
                for (int i = 1; i < loadingChars.Length; i++)
                {
                    loadingChars[i].GetComponent<CharaEffect>().PlayEffect();

                    yield return new WaitForSeconds(0.1f);
                }

                yield return new WaitForSeconds(1f);
            }
        }
    }
}


