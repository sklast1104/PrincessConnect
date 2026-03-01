# Princess Connect Re:Dive — 전투 시스템 모작

프린세스 커넥트 Re:Dive의 **수집형 RPG 전투 시스템**을 분석하고 재현한 개인 프로젝트입니다.
원작의 전투 흐름, UB(궁극기) 컷씬 연출, Wave 기반 스테이지 진행을 직접 설계하고 구현했습니다.

> 이 레포지토리는 전체 Unity 프로젝트가 아닌, 핵심 시스템 소스코드만 발췌한 포트폴리오용 레포입니다.

**시연 영상**: https://www.youtube.com/watch?v=IE32G41uqKw

---

## 핵심 시스템

### 1. FSM 기반 전투 상태 머신

Player와 Monster 각각 독립된 상태 머신을 설계했습니다.

```
StateMachine (base)
├── PlayerStateMachine — 12 States
│   ├── Start → StandBy → Idle ⇄ Move
│   │                      ↕
│   │                   Attack → Attacked
│   │                      ↓
│   │                    Skill (UB 컷씬)
│   │                      ↓
│   │              Next → Restart (웨이브 전환)
│   │                      ↓
│   │                    Clear → End
│   └── Wait (스킬 대기)
│
└── MonsterStateMachine — 9 States
    ├── Start → StandBy → Idle ⇄ Attack
    │                      ↕
    │                   Attacked → Die
    │                      ↓
    │               SkillDamaged (UB 피격)
    └── Wait / Restart
```

상태 전이는 **이벤트 드리븐** 방식으로 설계했습니다. `BattleManager`가 전장 상황(거리, 몬스터 생존 여부)을 판단하고 `OnMove`, `OnStop`, `OnAllDie` 이벤트를 발행하면, 각 상태가 자신에게 필요한 이벤트만 구독/해제하는 구조입니다. 이를 통해 상태 간 직접 참조 없이 느슨한 결합을 유지했습니다.

### 2. Timeline + PlayableDirector 기반 UB 컷씬 연출

원작의 UB(Union Burst) 연출을 재현했습니다.

```
SkillState (진입)
├── 1. CutSceneUIHandler 활성화 (연출 UI 오버레이)
├── 2. BattleManager.InvokeWait() — 전장 정지
├── 3. 타겟 몬스터 외 비활성화 + 동료 캐릭터 숨김
├── 4. 2초 대기 후 PlayableDirector.Play()
├── 5. Timeline Signal → 스킨 체인지 / 대미지 이벤트
└── 6. CutSceneHandler.DisActive() → 상태 복원 + Idle 전환
```

Timeline의 **Signal** 기능을 활용하여 컷씬 중 특정 타이밍에 Spine 스킨 체인지(`PecoSkinChanger`)와 대미지 이벤트를 발화합니다. 컷씬이 끝나면 `CutSceneHandler`가 몬스터 상태 복원과 UI 정리를 일괄 처리합니다.

### 3. Wave 기반 스테이지 관리

ScriptableObject 계층으로 스테이지 데이터를 구성했습니다.

```
Stage (ScriptableObject)
├── waves[3]          → Wave[]
│   └── Wave
│       ├── monsters[3]   → Monster (ScriptableObject)
│       └── wavePos[3]    → 스폰 위치
├── rewards[]         → 클리어 보상
└── mapName, bg[]     → 맵 정보
```

`StageManager`가 Wave 인덱스를 관리하며, 한 웨이브의 몬스터가 전멸하면 다음 웨이브의 몬스터를 `ResourceManager`를 통해 동적 생성합니다. 3웨이브 클리어 시 승리 연출(카메라 전환, 경험치 UI)이 코루틴 시퀀스로 진행됩니다.

### 4. Object Pool + ResourceManager 패턴

런타임 리소스 관리를 위한 매니저 시스템을 구축했습니다.

```
Manager (Singleton, DontDestroyOnLoad)
├── ResourceManager  — Resources.Load 래핑 + Pool 연동
├── PoolManager      — Queue 기반 오브젝트 풀
├── SoundManager     — BGM / SFX 관리
├── UIManager        — UI 생성/관리
└── SceneManagerEx   — 씬 전환
```

`ResourceManager.Instantiate()`가 호출되면 `Poolable` 컴포넌트 유무를 확인하여 풀에서 꺼내거나 새로 생성합니다. `Destroy()` 역시 풀링 대상이면 반환하고, 아니면 실제 파괴합니다. 대미지 폰트 UI 등 빈번하게 생성/파괴되는 오브젝트에 적용했습니다.

### 5. Spine 2D 애니메이션 통합

캐릭터 애니메이션은 **Spine 2D**로 구현했습니다.

- `SkeletonAnimation.AnimationState.SetAnimation()`으로 상태별 애니메이션 전환
- `AnimDataContainer`로 캐릭터별 애니메이션 이름 매핑 관리
- `TrackEntry.AnimationTime`을 추적하여 공격 타이밍에 대미지 판정 수행
- Signal 기반 스킨 체인지 — UB 컷씬에서 캐릭터 의상 변환

### 6. 전투 UI 시스템

원작의 전투 UI를 재현했습니다.

- **포트레이트 HUD**: 5인 파티 HP 바 + MP 게이지 (공격 시 MP 축적 → UB 발동)
- **대미지 폰트**: 오브젝트 풀 기반 팝업 텍스트
- **Wave 진행 UI**: 웨이브 전환 연출, 승리 화면, 경험치 UI
- **가차 연출**: Timeline 기반 가차 애니메이션 + 결과 화면

---

## 설계 고민

### DOTween vs Animator — UI 애니메이션 선택 기준

이 프로젝트에서 UI 애니메이션을 구현하면서 두 방식의 트레이드오프를 직접 경험했습니다.

- **DOTween**: 코드 기반으로 빠르게 프로토타이핑 가능하지만, Position/Rotation/Scale 동시 제어 시 시퀀스 중첩에서 값 충돌이 발생
- **Animator**: Animation Window에서 키프레임 커브를 정밀하게 제어 가능하지만, UI마다 Animator를 붙이면 매 프레임 상태 머신 평가 오버헤드 누적

**결론**: 단순 트윈(페이드, 슬라이드)은 DOTween, 복잡한 연출(UB 컷씬 UI, 멀티 프로퍼티 동기화)은 Animator로 분리 적용. 이 기준은 이후 실무(크로노아크)에서도 동일하게 적용했습니다.

### 이벤트 드리븐 상태 전이를 선택한 이유

각 State가 Enter()에서 필요한 이벤트를 구독하고 Exit()에서 해제하는 패턴을 사용합니다. 상태가 직접 다른 상태를 참조하지 않기 때문에, 새로운 상태 추가 시 기존 코드 수정 없이 이벤트만 구독하면 됩니다. Player 12개, Monster 9개 상태를 관리하면서도 상태 간 결합도를 낮게 유지할 수 있었습니다.

---

## 기술 스택

- **Unity 2021.3 + URP**
- **Spine 2D** — 캐릭터 애니메이션
- **Timeline + PlayableDirector** — UB 컷씬 연출
- **DOTween** — UI 트윈 애니메이션
- **ScriptableObject** — 스테이지/캐릭터/아이템 데이터

---

## 프로젝트 구조

```
├── Combat/
│   ├── BattleManager.cs          # 전장 상태 판단 + 이벤트 발행
│   ├── CharacterHandler.cs       # 파티 캐릭터 활성/비활성 관리
│   ├── Health.cs                 # HP/MP + 대미지/사망 이벤트
│   ├── DamageUIManager.cs        # 대미지 폰트 풀링
│   ├── CutScene/                 # UB 컷씬 핸들러
│   └── ...
├── State/
│   ├── State.cs                  # 추상 State 베이스
│   ├── StateMachine.cs           # Enter/Exit/Tick 상태 전환기
│   ├── Player/                   # 12개 플레이어 상태
│   │   ├── PlayerStateMachine.cs
│   │   ├── AttackState.cs        # Spine 애니메이션 타이밍 기반 대미지 판정
│   │   ├── SkillState.cs         # UB 컷씬 진입/종료 시퀀스
│   │   ├── MoveState.cs          # 거리 기반 이동/정지
│   │   └── ...
│   └── Monster/                  # 9개 몬스터 상태
│       ├── MonsterStateMachine.cs
│       ├── AttackState.cs        # Animator 기반 공격 + 대미지 판정
│       └── ...
├── Data/                         # ScriptableObject 데이터 정의
│   ├── Stage.cs                  # 스테이지 (3 Wave)
│   ├── Wave.cs                   # 웨이브 (몬스터 + 스폰 위치)
│   ├── Character.cs              # 캐릭터 스탯
│   └── Monster.cs, Item.cs
├── Manager/
│   ├── Manager.cs                # 중앙 매니저 Singleton
│   ├── ResourceManager.cs        # 리소스 로드 + Pool 연동
│   ├── PoolManager.cs            # Queue 기반 오브젝트 풀
│   ├── SoundManager.cs           # BGM / SFX
│   └── Game/
│       ├── StageManager.cs       # Wave 진행 + 몬스터 스폰
│       └── RosterManager.cs      # 파티 편성
├── UI/
│   ├── BattleSceneUI/            # 전투 HUD (포트레이트, HP, 대미지)
│   ├── GachaUI/                  # 가차 연출
│   ├── CharInvUI/                # 캐릭터 인벤토리
│   ├── CommonUI/                 # 공통 UI (네비게이션, 페이더)
│   └── ...
├── Signal/                       # Timeline Signal (Spine 스킨 체인지)
├── Camera/                       # 스테이지 클리어 카메라
└── Scene/                        # 씬 관리 (Title, Main, Battle)
```
