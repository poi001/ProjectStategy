using UnityEngine;

public class CharacterAnimationData
{
    [SerializeField] private string moveParameterName = DefineClass.CharacterAnimationParameter_Move;
    [SerializeField] private string attackParameterName = DefineClass.CharacterAnimationParameter_Attack;
    [SerializeField] private string skillParameterName = DefineClass.CharacterAnimationParameter_Skill;
    [SerializeField] private string stunParameterName = DefineClass.CharacterAnimationParameter_Stun;
    [SerializeField] private string deathParameterName = DefineClass.CharacterAnimationParameter_Death;
    [SerializeField] private string isDeathParameterName = DefineClass.CharacterAnimationParameter_IsDeath;
    [SerializeField] private string meleeTypeParameterName = DefineClass.CharacterAnimationParameter_MeleeType;
    [SerializeField] private string weaponTypeParameterName = DefineClass.CharacterAnimationParameter_WeaponType;

    public int MoveParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int SkillParameterHash { get; private set; }
    public int StunParameterHash { get; private set; }
    public int DeathParameterHash { get; private set; }
    public int IsDeathParameterHash { get; private set; }
    public int MeleeTypeParameterHash { get; private set; }
    public int WeaponTypeParameterHash { get; private set; }


    public CharacterAnimationData()
    {
        Initialize();
    }

    public void Initialize()
    {
        MoveParameterHash = Animator.StringToHash(moveParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        SkillParameterHash = Animator.StringToHash(skillParameterName);
        StunParameterHash = Animator.StringToHash(stunParameterName);
        DeathParameterHash = Animator.StringToHash(deathParameterName);
        IsDeathParameterHash = Animator.StringToHash(isDeathParameterName);
        MeleeTypeParameterHash = Animator.StringToHash(meleeTypeParameterName);
        WeaponTypeParameterHash = Animator.StringToHash(weaponTypeParameterName);
    }
}
