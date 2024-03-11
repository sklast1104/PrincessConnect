using System;
using System.Collections;
using Jun.Combat;
using Jun.Data;
using Jun.Manage;
using Jun.MyCamera;
using Jun.UI.BattleScene;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

// 여기서 스테이지 몬스터들을 관리함
// 모든 몬스터들이 죽음을 알리는 로직은 배틀매니저에서 하는게 아니라
// 여기서 이벤트 호출을 하는게 직관적일거 같음
public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterContainer;
    
    [SerializeField]
    private Stage stage;

    private Wave[] _waves;

    private Wave _curWave;

    [field:SerializeField]
    public GameObject[] CurMonsters { get; private set; }

    public Action NextStageEvent;
    public Action ClearStageEvent;

    private BattleManager _battleManager;
    private MainUIHandler _mainUIHandler;
    private WinUIHandler _winUIHandler;
    private ExpUIHandler _expUIHandler;
    private StageClearCamera _clearCamera;
    private StartUIHandler _startUIHandler;
    
    
    [field:SerializeField]
    public int waveIndex { get; private set; }
    
    private void Awake()
    {
        _battleManager = FindObjectOfType<BattleManager>(true);
        _mainUIHandler = FindObjectOfType<MainUIHandler>(true);
        _winUIHandler = FindObjectOfType<WinUIHandler>(true);
        _clearCamera = FindObjectOfType<StageClearCamera>(true);
        _expUIHandler = FindObjectOfType<ExpUIHandler>(true);
        _startUIHandler = FindObjectOfType<StartUIHandler>(true);

        monsterContainer = GameObject.Find("Monsters");
        stage = Manager.Resource.Load<Stage>("Scriptable/Stage/1-1/1-1");
        _waves = stage.waves;
        waveIndex = 0;
        _curWave = _waves[waveIndex];
        CurMonsters = new GameObject[3];
        
        MakeCurWaveMonsters();
    }

    private void Start()
    {
        waveIndex = 0;

        StartCoroutine(StartEffect());
    }

    IEnumerator StartEffect()
    {
        yield return new WaitForSeconds(3.5f);
        
        _startUIHandler.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        
        _startUIHandler.gameObject.SetActive(false);
    }

    public void MakeNextStage()
    {
        waveIndex += 1;
        _curWave = _waves[waveIndex];
    
        MakeCurWaveMonsters();

        BattleManager[] managers = FindObjectsOfType<BattleManager>();

        for (int i = 0; i < managers.Length; i++)
        {
            managers[i].AllDieChecked = true;
        }
        
    }
    
    void MakeCurWaveMonsters()
    {
        for (int i = 0; i < _curWave.monsters.Length; i++)
        {
            if (_curWave.monsters[i] == null)
            {
                continue;
            }
            
            GameObject mon = Manager.Resource.Load<GameObject>(
                "Prefabs/" +  _curWave.monsters[i].prefabPath);
            mon.transform.position = _curWave.wavePos[i];
            
            GameObject instMon = Object.Instantiate<GameObject>(mon, monsterContainer.transform);
            
            CurMonsters[i] = instMon;
        }
    }
    
    private void OnEnable()
    {
        _battleManager.OnAllDie += AllDieHandler;
        NextStageEvent += MakeNextStage;
        ClearStageEvent += ClearStageHandler;
    }

    private void OnDisable()
    {
        _battleManager.OnAllDie -= AllDieHandler;
        NextStageEvent -= MakeNextStage;
        ClearStageEvent -= ClearStageHandler;
    }

    void ClearStageHandler()
    {
        StartCoroutine(DelayedActive());
    }

    IEnumerator DelayedActive()
    {
        yield return new WaitForSeconds(1.2f);
        _mainUIHandler.EnActive(false);

        yield return new WaitForSeconds(0.8f);
        _winUIHandler.gameObject.SetActive(true);
        _clearCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        _winUIHandler.StartAnimation();

        yield return new WaitForSeconds(1f);
        _expUIHandler.gameObject.SetActive(true);
    }
    
    private void AllDieHandler()
    {
        if (waveIndex == 2)
        {
            ClearStageEvent?.Invoke();
        }
        else
        {
            StartCoroutine(WaitAndInvoke());
        }
    }

    private IEnumerator WaitAndInvoke()
    {
        yield return new WaitForSeconds(4.5f);
        NextStageEvent?.Invoke();
    }
}
