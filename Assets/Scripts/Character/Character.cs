using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 컴포넌트
    public Animator Animator { get; protected set; }
    public BoxCollider2D Collider { get; protected set; }

    // MonoBehaviour가 없는 클래스
    public CharacterMovement Movement { get; protected set; }
    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }
    public CharacterAttackAction AttackAction { get; protected set; }
    public CharacterSearchingTarget SearchingTarget { get; protected set; }
    public CharacterSkillData SkillData { get; protected set; }

    // 캐릭터의 상세 정보
    [SerializeField] private CharacterStatScriptableObject _statSO;
    public ECharacterType CharacterType { get; private set; } = ECharacterType.None;
    public EWeaponType WeaponType { get; private set; } = EWeaponType.None;
    public bool IsPlayerTeam { get; private set; } = true;

    // 기타
    [HideInInspector]
    public Character Target;
    [HideInInspector]
    public Vector2 Direction = Vector2.zero;
    public bool IsFacingLeft { get; private set; } = true;
    public Transform MuzzleTransform;
    [SerializeField] private bool _isAutoSetComponent = true;

    // 델리게이트
    public Action OnDeath;
    public Action OnDamaged;
    public Action OnRegenMana;
    public Action OnUseMana;
    public Action OnUpdate;
    public Action OnChangePassive;
    public Action OnChangeSkill;
    public Action OnChangeUltSkill;
    //구현해야 할 것
    public Action OnAttack;
    public Action OnSkill;


    private void OnDisable()
    {
        OnDeath = null;
        OnDamaged = null;
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    public void InitCharacter(bool isAlly)
    {
        //AddOrGetComponent();

        // 컴포넌트
        Animator = GetComponentInChildren<Animator>();

        // 타입
        CharacterType = _statSO.CharacterType;
        WeaponType = _statSO.WeaponType;

        // 클래스
        Stats = new CharacterStat(this, _statSO);
        AnimationData = new CharacterAnimationData();
        StateMachine = new CharacterStateMachine(this);
        //SettingCharacterType(CharacterType);
        SearchingTarget = new CharacterSearchingTarget(this);
        SkillData = new CharacterSkillData(this);

        // 레이어, 태그 설정
        SettingTeam(isAlly);

        // 델리게이트
        OnDeath += Death;

        // 처음 상태 설정
        StateMachine.ChanageState(StateMachine.moveState);
    }

    //private void AddOrGetComponent()    // 컴포넌트 붙이기
    //{
    //    Collider = gameObject.GetOrAddComponent<BoxCollider2D>();


    //    if (_isAutoSetComponent)
    //    {

    //    }
    //    else
    //    {

    //    }


    //}

    //private void SettingCharacterType(ECharacterType characterType)
    //{
    //    switch (characterType)
    //    {
    //        case ECharacterType.Melee:
    //            Movement = new MeleeMovement(this);
    //            AttackAction = new MeleeAttackAction(this);
    //            break;
    //        case ECharacterType.Ranged:
    //        case ECharacterType.Magician:
    //            Movement = new RangedMovement(this);
    //            AttackAction = new RangedAttackAction(this);
    //            break;
    //        default:
    //            break;
    //    }
    //}

    private void SettingTeam(bool isPlayerTeam)
    {
        IsPlayerTeam = isPlayerTeam;

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
    }

    public void Flip()
    {
        IsFacingLeft = !IsFacingLeft;

        Vector3 localScale = transform.localScale; // 현재 스케일의 x 값 반전
        localScale.x *= -1.0f; // 좌우 반전
        transform.localScale = localScale;
    }

    public void SpawnAttackObject()
    {
        if (_statSO.BasicAttackFactorySO == null) return;


        var objAndInterface = _statSO.BasicAttackFactory.Create(MuzzleTransform.position);
        objAndInterface.Init(this);
    }

    private void Death()
    {
        StateMachine.ChanageState(StateMachine.deathState);
        gameObject.tag = gameObject.CompareTag(DefineClass.Tag_Player) ? DefineClass.Tag_DeadPlayer : DefineClass.Tag_DeadEnemy;
    }

    public void Revival()
    {
        StateMachine.ChanageState(StateMachine.idleState);
        gameObject.tag = gameObject.tag == DefineClass.Tag_DeadPlayer ? DefineClass.Tag_Player : DefineClass.Tag_Enemy;
    }
}
