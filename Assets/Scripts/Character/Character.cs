using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    // 컴포넌트
    public Animator Animator { get; protected set; }
    public CharacterMovement Movement { get; protected set; }

    // MonoBehaviour가 없는 클래스
    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }
    public CharacterAttackTimer AttackTimer { get; protected set; }
    public CharacterAttackAction AttackAction { get; protected set; }

    // 직렬화
    [SerializeField]
    private CharacterStatScriptableObject statSO;

    // 캐릭터의 상세 정보
    public ECharacterType CharacterType { get; private set; } = ECharacterType.None;
    public EWeaponType WeaponType { get; private set; } = EWeaponType.None;
    public bool IsPlayerTeam { get; private set; } = true;

    // 오브젝트 ( 평타, 스킬 )
    public GameObject NormalAttackObject { get; private set; }
    public GameObject SkillObject { get; private set; }
    public GameObject UltimateObject { get; private set; }

    // 기타
    public Character Target { get; private set; }
    public Vector2 _dir = Vector2.zero;
    public bool _isFacingLeft = true;

    // 델리게이트
    public Action OnDeath;
    public Action OnDamaged;
    public Action OnRegenMana;
    public Action OnUseMana;

    private void OnDisable()
    {
        OnDeath = null;
        OnDamaged = null;
    }

    // temp
    private void Awake()
    {
        InitCharacter();
    }
    private void Start()
    {
        StateMachine.ChanageState(StateMachine.moveState);
    }

    private void Update()
    {
        // temp Target
        if(StateMachine != null && StateMachine.CurrentCharacterState != ECharacterState.Attack)
            Target = BattleManager.Instance.GetNearEnemy(IsPlayerTeam, transform.position);

        // 스테이트 머신의 Update
        if(StateMachine != null && StateMachine.currentState != null) StateMachine.Update();

        // 공격 타이머
        if (AttackTimer != null) AttackTimer.UpdateAttackTimer();
    }

    public void InitCharacter()
    {
        // 타입
        CharacterType = statSO.CharacterType;
        WeaponType = statSO.WeaponType;

        // 오브젝트
        NormalAttackObject = statSO.NormalAttackObject;
        SkillObject = statSO.SkillObject;
        UltimateObject = statSO.UltimateObject;

        // 클래스
        Stats = new CharacterStat(this, statSO);
        StateMachine = new CharacterStateMachine(this);
        AnimationData = new CharacterAnimationData();
        AttackTimer = new CharacterAttackTimer(this);
        SettingCharacterType(CharacterType);

        // 컴포넌트
        Animator = GetComponentInChildren<Animator>();

        // 레이어, 태그 설정
        if (transform.position.x < 0.0f) IsPlayerTeam = true; // temp
        else IsPlayerTeam = false; // temp
        if (IsPlayerTeam)
        {
            gameObject.layer = LayerMask.NameToLayer(DefineClass.Layer_Player);
            gameObject.tag = DefineClass.Tag_Player;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer(DefineClass.Layer_Enemy);
            gameObject.tag = DefineClass.Tag_Enemy;
        }

        // 델리게이트
        OnDeath += Death;
    }

    private void SettingCharacterType(ECharacterType characterType)
    {
        switch (characterType)
        {
            case ECharacterType.Melee:
                Movement = new MeleeMovement(this);
                AttackAction = new MeleeAttackAction(this);
                break;
            case ECharacterType.Ranged:
            case ECharacterType.Magician:
                Movement = new RangedMovement(this);
                AttackAction = new RangedAttackAction(this);
                break;
            default:
                break;
        }
    }

    public void Flip()
    {
        _isFacingLeft = !_isFacingLeft;

        Vector3 localScale = transform.localScale; // 현재 스케일의 x 값 반전
        localScale.x *= -1.0f; // 좌우 반전
        transform.localScale = localScale;
    }

    public void SpawnAttackObject(EAttackObject attackObject)
    {
        switch (attackObject)
        {
            case EAttackObject.Normal:
                Instantiate(NormalAttackObject, transform.position, Quaternion.identity).
                    GetComponent<AttackObject>().Init(this);
                break;
            case EAttackObject.Skill:
                break;
            case EAttackObject.Ult:
                break;
            default:
                break;
        }
    }

    private void Death()
    {
        StateMachine.ChanageState(StateMachine.deathState);
        gameObject.tag = gameObject.tag == DefineClass.Tag_Player ? DefineClass.Tag_DeadPlayer : DefineClass.Tag_DeadEnemy;
    }

    public void Revival()
    {
        StateMachine.ChanageState(StateMachine.idleState);
        gameObject.tag = gameObject.tag == DefineClass.Tag_DeadPlayer ? DefineClass.Tag_Player : DefineClass.Tag_Enemy;
    }
}
