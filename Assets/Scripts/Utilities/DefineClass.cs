public enum EGameState
{
    None = 0,
    Title,
    Lobby,
    Battle,
    Room,
    Result
}
public enum ECharacterState
{
    None = 0,
    Idle,
    Move,
    Attack,
    Skill,
    Stun,
    Death
}
public enum ECharacterStatType
{
    MaxHP = 0,
    MaxMP,
    Armor,
    MagicResistance,
    AttackDamage,
    AbilityPower,
    AttackSpeed,
    CriticalProbability,
    CriticalDamage,
    MoveSpeed,
    Stamina,
    IncreasedDamage,
    Drain,
    Range
}
public enum EStatApplyType
{
    Flat = 0,
    Percent = 1,
    Const = 2
}
public enum ECharacterType
{
    None = 0,
    Melee,
    Ranged,
    Magician,
    Healer
}
public enum EWeaponType
{
    None = 0,
    Normal,
    Axe,
    ShortSword,
    LongSpear,
    Bow,
    Staff
}

public class DefineClass
{
    // 팀 최대 인원
    public const int NumberOfPlayers = 5;

    // 애니메이션 Parameters
    public const string CharacterAnimationParameter_Move = "1_Move";
    public const string CharacterAnimationParameter_Attack = "2_Attack";
    public const string CharacterAnimationParameter_Skill = "7_Skill";
    public const string CharacterAnimationParameter_Stun = "5_Debuff";
    public const string CharacterAnimationParameter_Death = "4_Death";
    public const string CharacterAnimationParameter_IsDeath = "isDeath";
    public const string CharacterAnimationParameter_MeleeType = "MeleeType";
    public const string CharacterAnimationParameter_WeaponType = "WeaponType";

    // 코루틴 키 값
    public const string FindToTargetCoroutineKey = "FindToTarget";
}
