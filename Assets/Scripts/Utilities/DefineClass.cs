using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagerInterface
{
    public IEnumerator Init();
}
public interface IManagerWithSceneInterface
{
    public IEnumerator Init();
}
public interface IAttackAction
{
    public void Attack();
}
public interface IAttackObjectFactory
{
    public IAttackObject Create(Vector3 pos);
}
public interface IAttackObject
{
    public void Init(Character owner);
}
public interface IMoveAction
{
    public void Move();
}
public interface ISkill
{
    public IEnumerator StartBattleScene();
    public void EndBattleScene();
    public void Equip(Character character);
    public void Unequip();
    public void ActiveSkill();
    public void DeactiveSkill();
    // 스탯 정보 주는 딕셔너리를 반환하는 함수
    // 스택 반환
    // 버프 시간 반환
    // 버프 적용 타입 반환
}
public interface ISkill_Stat
{

}
public interface ISkill_Effect
{

}
public interface ISkill_Buff
{

}
public interface ISkill_Stack
{

}
public interface ISkill_Flat
{

}
public interface IBuff
{
    public void Apply();
    public void Remove();
    public void SetPermanent(bool isItPermanent);
    public void SetTimer(float time);
}
public interface ISkillStatSO
{
    public Dictionary<ECharacterStatType, float> GetApplyStatDict();
    public int GetMaxStack();
    public float GetDuring();
    public EStatApplyType GetStatApplyType();
    public EStackType GetStackType();
}
public interface ISkillEffectSO
{

}


public enum EGameState
{
    None = 0,
    Load,
    Bootstrap,
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
    Drain,
    Range,
    RegenHPWhenHitting,
    RegenMPWhenHitting,
    ExtraDamageWhenHitting_AD,
    ExtraDamageWhenHitting_AP,
    IncreaseShieldQuantity
}
public enum EStatApplyType
{
    Flat = 0,
    Percent = 1,
    Const = 2
}
public enum ECharacterType
{
    Melee = 0,
    Ranged
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
public enum ECharacterTierType
{
    Normal = 0,
    Hero,
    Legendary
}
public enum ESkillTierType
{
    Normal = 0,
    Hero,
    Legendary
}
public enum ERaceSynergyType
{
    Human = 0,
    Elf,
    Undead
}
public enum EWeaponSynergyType
{
    None = 0,
    Sword,
    ShotSword,
    Axe,
    LongSpear,
    Shield,
    Blunt,
    Bow,
    Staff
}
public enum EAttackType
{
    BasicAttack = 0,
    Passive,
    Skill
}
public enum ECombatType
{
    Balanced = 0,   // 중거리 밸런스형
    Aggressive,     // 근거리 돌진형
    Defensive,      // 거리 유지형 (원거리)
    Supportive      // 아군 근처 유지형
}
public enum EDebuffType
{
    Slow = 0,
    Stun,
    Blind,
    Silence
}
public enum EDamageType
{
    AD = 0,
    AP,
    True
}
public enum EStackType
{
    Attack = 0,
    Damaged,
    Skill,
    Move
}


public static class DefineClass
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

    // 씬
    public const string Scene_Bootstrap = "BootstrapScene";
    public const string Scene_Battle = "BattleScene";
    public const string Scene_Lobby = "LobbyScene";
    public const string Scene_Title = "TitleScene";
    public const string Scene_Load = "LoadScene";

    // 스폰 위치


    // UI Canvas 이름
    public const string UI_HPMPBarUICanvas = "HPMPBarUICanvas";
    public const string UI_LobbyUICanvas = "LobbyUICanvas";

    // Resources 경로
    public const string Path_UICanvas = "Prefabs/UI/Canvas";
}
