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
public enum ECharacterType
{
    None = 0,
    Melee,
    Ranged,
    Magician
}

public class DefineClass
{
    // 팀 최대 인원
    public const int NumberOfPlayers = 5;

    // 애니메이션 Parameters
    public const string CharacterAnimationParameter_Idle = "Idle";
    public const string CharacterAnimationParameter_Move = "Move";
    public const string CharacterAnimationParameter_Attack = "Attack";
    public const string CharacterAnimationParameter_Skill = "Skill";
    public const string CharacterAnimationParameter_Stun = "Stun";
    public const string CharacterAnimationParameter_Death = "Death";
}
