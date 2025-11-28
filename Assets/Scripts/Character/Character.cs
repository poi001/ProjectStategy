using System;
using UnityEditor.Timeline.Actions;
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
    public ECombatType CombatType { get; private set; } = ECombatType.Balanced;
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
        OnRegenMana = null;
        OnUseMana = null;
        OnUpdate = null;
        OnChangePassive = null;
        OnChangeSkill = null;
        OnChangeUltSkill = null;

        OnAttack = null;
        OnSkill = null;
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }

    public void InitCharacter(bool isAlly)
    {
        // 컴포넌트
        Animator = GetComponentInChildren<Animator>();

        // 타입
        CharacterType = _statSO.CharacterType;
        WeaponType = _statSO.WeaponType;
        //CombatType = PlayerDataScriptableObject.Instance.

        // 클래스
        //Stats = new CharacterStat(this, _statSO);
        AnimationData = new CharacterAnimationData();
        StateMachine = new CharacterStateMachine(this);
        AttackAction = new CharacterAttackAction(this);
        SearchingTarget = new CharacterSearchingTarget(this);
        SkillData = new CharacterSkillData(this);

        // 레이어, 태그 설정
        SettingTeam(isAlly);

        // 델리게이트
        OnDeath += Death;

        // 처음 상태 설정
        StateMachine.ChanageState(StateMachine.moveState);
    }

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
