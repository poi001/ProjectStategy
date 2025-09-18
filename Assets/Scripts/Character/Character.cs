using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator Animator { get; protected set; }

    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }

    [SerializeField]
    private CharacterStatScriptableObject statSO;
    public bool IsPlayerTeam { get; private set; } = true;
    //public EWeaponType CharacterType { get; private set; } = EWeaponType.None;

    private float _attackTimer = 0.0f;


    private void Start()
    {
        InitCharacter();

        if (transform.position.x < 0.0f) IsPlayerTeam = true;
        else IsPlayerTeam = false;

        StateMachine.ChanageState(StateMachine.moveState);
    }

    private void Update()
    {
        if(StateMachine != null && StateMachine.currentState != null) StateMachine.Update();

        if (_attackTimer > 0.0f) _attackTimer -= Time.deltaTime;
    }

    public void InitCharacter()
    {
        Stats = new CharacterStat(statSO);
        StateMachine = new CharacterStateMachine(this);
        AnimationData = new CharacterAnimationData();

        Animator = GetComponentInChildren<Animator>();
    }

    public bool Attack()
    {
        if (_attackTimer <= 0.0f)
        {
            float attackSpeed = Stats.AttackSpeed <= 0.01f ? 0.01f : Stats.AttackSpeed;
            _attackTimer = 1.0f / Stats.AttackSpeed;
            return true;
        }

        return false;
    }
}
