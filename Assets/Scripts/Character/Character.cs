using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMovement Movement { get; private set; }
    public CharacterStat Stat { get; private set; }
    public CharacterStateMachine StateMachine { get; private set; }
    public CharacterAnimationData animationData { get; protected set; }

    public bool IsPlayerTeam { get; private set; }
    public ECharacterType CharacterType { get; private set; }


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

        Movement.InitMovement(this);
        //Stat.InitStat(this);
    }
}
