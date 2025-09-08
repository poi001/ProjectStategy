using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationData : MonoBehaviour
{
    [SerializeField] private string idleParameterName = DefineClass.CharacterAnimationParameter_Idle;
    [SerializeField] private string moveParameterName = DefineClass.CharacterAnimationParameter_Move;
    [SerializeField] private string attackParameterName = DefineClass.CharacterAnimationParameter_Attack;
    [SerializeField] private string skillParameterName = DefineClass.CharacterAnimationParameter_Skill;
    [SerializeField] private string stunParameterName = DefineClass.CharacterAnimationParameter_Stun;
    [SerializeField] private string deathParameterName = DefineClass.CharacterAnimationParameter_Death;

    public int idleParameterHash { get; private set; }
    public int moveParameterHash { get; private set; }
    public int attackParameterHash { get; private set; }
    public int skillParameterHash { get; private set; }
    public int stunParameterHash { get; private set; }
    public int deathParameterHash { get; private set; }


    public CharacterAnimationData()
    {
        Initialize();
    }

    public void Initialize()
    {
        idleParameterHash = Animator.StringToHash(idleParameterName);
        moveParameterHash = Animator.StringToHash(moveParameterName);
        attackParameterHash = Animator.StringToHash(attackParameterName);
        skillParameterHash = Animator.StringToHash(skillParameterName);
        stunParameterHash = Animator.StringToHash(stunParameterName);
        deathParameterHash = Animator.StringToHash(deathParameterName);
    }
}
