using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public Animator Animator { get; protected set; }
    public CharacterMovement Movement { get; protected set; }

    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }
    public CharacterAttackTimer AttackTimer { get; protected set; }

    [SerializeField]
    private CharacterStatScriptableObject statSO;
    [SerializeField]
    private ECharacterType _characterType = ECharacterType.Melee;
    [SerializeField]
    private EWeaponType _weaponType = EWeaponType.Normal;

    public ECharacterType CharacterType { get; private set; } = ECharacterType.None;
    public EWeaponType WeaponType { get; private set; } = EWeaponType.None;
    public bool IsPlayerTeam { get; private set; } = true;

    public Character Target { get; private set; }
    public Vector2 _dir = Vector2.zero;
    public bool _isFacingLeft = true;


    private void Start()
    {
        InitCharacter();

        // temp
        if (transform.position.x < 0.0f) IsPlayerTeam = true;
        else IsPlayerTeam = false;

        StateMachine.ChanageState(StateMachine.moveState);
    }

    private void Update()
    {
        // temp Target
        Target = BattleManager.Instance.GetNearEnemy(IsPlayerTeam, transform.position);

        // 스테이트 머신의 Update
        if(StateMachine != null && StateMachine.currentState != null) StateMachine.Update();

        // 공격 타이머
        AttackTimer.UpdateAttackTimer();
    }

    public void InitCharacter()
    {
        CharacterType = _characterType;
        WeaponType = _weaponType;

        Stats = new CharacterStat(statSO);
        StateMachine = new CharacterStateMachine(this);
        AnimationData = new CharacterAnimationData();
        AttackTimer = new CharacterAttackTimer(this);
        SelectMovement(_characterType);

        Animator = GetComponentInChildren<Animator>();
    }

    private void SelectMovement(ECharacterType characterType)
    {
        switch (characterType)
        {
            case ECharacterType.Melee:
                Movement = new MeleeMovement(this);
                break;
            case ECharacterType.Ranged:
            case ECharacterType.Magician:
                Movement = new RangedMovement(this);
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
}
