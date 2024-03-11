using System;
using DG.Tweening;
using UnityEngine;

namespace Jun.Combat
{
    public class BattleManager : MonoBehaviour
    {
        [field:SerializeField]
        public GameObject curFrontMon { get; private set; }
        [field:SerializeField]
        public GameObject curFrontPrin { get; private set; }
        
        // 여기는 아마 스테이지를 바탕으로 몬스터를 계산해야할것
        // 일단 배열을 바탕으로 계산하자

        public GameObject[] monsters;

        [SerializeField] private float _xlimit ;
        [SerializeField] private float xDist;

        public Action OnAllDie;
        public Action OnMove;
        public Action OnStop;

        public Action OnWait;
        public Action OnSkillEnd;

        public bool AllDieChecked = true;

        private StageManager _stageManager;
        
        private void Awake()
        {
            _stageManager = FindObjectOfType<StageManager>(true);
            curFrontPrin = gameObject;
        }

        private void Start()
        {
            monsters = _stageManager.CurMonsters;
        }

        private float delay = 1f;
        private float elapsedTime = 0f;

        private void Update()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime < delay) return;
            
            xDist = (FindMinXMonster().transform.position.x + 1) - curFrontPrin.transform.position.x;
            xDist = Mathf.Abs(xDist);
            
            if (CheckAllDead())
            {
                if (AllDieChecked)
                {
                    AllDieChecked = false;
                    OnAllDie?.Invoke();
                }
            } 
            else if (xDist > _xlimit)
            {
                OnMove?.Invoke();
            }
            else
            {
                OnStop?.Invoke();
            }
        }

        private bool CheckAllDead()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == null) continue;

                Health health = monsters[i].GetComponentInChildren<Health>(true);

                if (!health.isDead)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        public GameObject FindMinXMonster()
        {
            if (monsters.Length == 0)
            {
                return null;
            }

            GameObject minObj = monsters[0];
            float closestDist = float.MaxValue;

            for (int i = 0; i < monsters.Length; i++)
            {
                if (null == monsters[i]) continue;
                
                Health health = monsters[i].GetComponentInChildren<Health>(true);
                
                if (monsters[i].transform.position.x < closestDist && !health.isDead)
                {
                    closestDist = monsters[i].transform.position.x;
                    minObj = monsters[i];
                }
            }

            curFrontMon = minObj;
            return minObj;
        }
        
        public void DisableExceptMinX()
        {
            GameObject mon = FindMinXMonster();
            if (mon == null) return;

            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] != null && mon != monsters[i])
                {
                    monsters[i].SetActive(false);
                }
            }
        }

        public void RestoreMonsterState()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if(monsters[i] != null) monsters[i].SetActive(true);
            }
        }

        public void InvokeWait()
        {
            OnWait?.Invoke();
        }

        public void InvokeSkillEnd()
        {
            OnSkillEnd?.Invoke();
        }
        
    }
}