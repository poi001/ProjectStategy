using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMovement Movement { get; private set; }
    public Animator Animator { get; protected set; }

    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }
    public CharacterStat Stats { get; protected set; }

    [SerializeField]
    private CharacterStatScriptableObject statSO;
    public bool IsPlayerTeam { get; private set; } = true;
    //public EWeaponType CharacterType { get; private set; } = EWeaponType.None;


    private void Start()
    {
        InitCharacter();

        if (transform.position.x < 0.0f) IsPlayerTeam = true;
        else IsPlayerTeam = false;
    }

    public void InitCharacter()
    {
        Stats = new CharacterStat(statSO);
        StateMachine = new CharacterStateMachine(this);
        AnimationData = new CharacterAnimationData();

        Movement = GetComponent<CharacterMovement>();
        if (Movement == null) Movement = gameObject.AddComponent<CharacterMovement>();
        Animator = GetComponentInChildren<Animator>();

        Movement.InitMovement(this);
    }
}
