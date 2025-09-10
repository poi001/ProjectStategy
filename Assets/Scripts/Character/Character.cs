using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMovement Movement { get; private set; }
    public CharacterStat Stat { get; private set; }
    public Animator Animator { get; protected set; }

    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData AnimationData { get; protected set; }

    public bool IsPlayerTeam { get; private set; } = true;
    public EWeaponType CharacterType { get; private set; } = EWeaponType.None;


    private void Start()
    {
        InitCharacter();

        if (transform.position.x < 0.0f) IsPlayerTeam = true;
        else IsPlayerTeam = false;
    }

    public void InitCharacter()
    {
        Movement = GetComponent<CharacterMovement>();
        Stat = GetComponent<CharacterStat>();
        Animator = GetComponentInChildren<Animator>();

        Movement.InitMovement(this);
        //Stat.InitStat(this);
    }
}
