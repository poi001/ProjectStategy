using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 컴포넌트
    public Animator Animator { get; protected set; }
    public CharacterMovement Movement { get; protected set; }

    // MonoBehaviour가 없는 클래스
    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }
    public CharacterAttackAction AttackAction { get; protected set; }

    // 직렬화
    [SerializeField]
    private CharacterStatScriptableObject _statSO;
    public Transform MuzzleTransform;

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
    [HideInInspector]
    public Vector2 _dir = Vector2.zero;
    [HideInInspector]
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

    private void Update()
    {
        // temp Target
        if(StateMachine != null && StateMachine.CurrentCharacterState != ECharacterState.Attack)
        {
            if(IsPlayerTeam) Target = BattleManager.Instance.GetEnemyCharacters(this)[0].Item2;
            else Target = BattleManager.Instance.GetAllyCharacters(this)[0].Item2;
        }
        else Target = null;

        // 스테이트 머신의 Update
        if (StateMachine != null && StateMachine.currentState != null) StateMachine.Update();

        // 공격 타이머
        if (AttackAction != null) AttackAction.UpdateAttackTimer();
    }

    public void InitCharacter(bool isAlly)
    {
        // 컴포넌트
        Animator = GetComponentInChildren<Animator>();

        // 타입
        CharacterType = _statSO.CharacterType;
        WeaponType = _statSO.WeaponType;

        // 오브젝트
        NormalAttackObject = _statSO.NormalAttackObject;
        SkillObject = _statSO.SkillObject;
        UltimateObject = _statSO.UltimateObject;

        // 클래스
        Stats = new CharacterStat(this, _statSO);
        AnimationData = new CharacterAnimationData();
        StateMachine = new CharacterStateMachine(this);
        SettingCharacterType(CharacterType);

        // 레이어, 태그 설정
        SettingTeam(isAlly);

        // 델리게이트
        OnDeath += Death;

        // 처음 상태 설정
        StateMachine.ChanageState(StateMachine.moveState);
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
        _isFacingLeft = !_isFacingLeft;

        Vector3 localScale = transform.localScale; // 현재 스케일의 x 값 반전
        localScale.x *= -1.0f; // 좌우 반전
        transform.localScale = localScale;
    }

    public void SpawnAttackObject(EAttackObject attackObject, Vector3 pos)
    {
        switch (attackObject)
        {
            case EAttackObject.Normal:
                Instantiate(NormalAttackObject, pos, Quaternion.identity).
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
        gameObject.tag = gameObject.CompareTag(DefineClass.Tag_Player) ? DefineClass.Tag_DeadPlayer : DefineClass.Tag_DeadEnemy;
    }

    public void Revival()
    {
        StateMachine.ChanageState(StateMachine.idleState);
        gameObject.tag = gameObject.tag == DefineClass.Tag_DeadPlayer ? DefineClass.Tag_Player : DefineClass.Tag_Enemy;
    }
}
