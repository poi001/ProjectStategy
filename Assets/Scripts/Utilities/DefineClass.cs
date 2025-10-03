public interface IAboutSceneManager
{
    public EGameState State { get; }

    public void EnterScene();
    public void ExitScene();
}


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
    ArmorPenetration_Flat,
    ArmorPenetration_Percent,
    MagicResistance,
    MagicResistancePenetration_Flat,
    MagicResistancePenetration_Percent,
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
public enum EAttackObject
{
    Normal = 0,
    Skill,
    Ult
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

    // 레이어
    public const string Layer_Ignore = "Ignore Raycast";
    public const string Layer_Player = "Player";
    public const string Layer_Enemy = "Enemy";
    public const string Layer_Skill = "Skill";
    public const string Layer_PlayerSkill = "PlayerSkill";
    public const string Layer_EnemySkill = "EnemySkill";

    // 태그
    public const string Tag_Player = "Player";
    public const string Tag_Enemy = "Enemy";
    public const string Tag_Skill = "Skill";
    public const string Tag_PlayerSkill = "PlayerSkill";
    public const string Tag_EnemySkill = "EnemySkill";
    public const string Tag_DeadPlayer = "DeadPlayer";
    public const string Tag_DeadEnemy = "DeadEnemy";

    // 매니저 딕셔너리 키 값
    public const string MngDictKey_BattleManager = "BattleManager";
}
