using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStat
{
    // Battle Stats
    private Stat _maxHP;
    private Stat _maxMP;
    private Stat _armor;
    private Stat _magicResistance;
    private Stat _attackDamage;
    private Stat _abilityPower;
    private Stat _attackSpeed;
    private Stat _criticalProbability;
    private Stat _criticalDamage;
    private Stat _moveSpeed;
    private Stat _stamina;
    private Stat _increasedDamage;
    private Stat _drain;
    private Stat _range;

    public float MaxHP => _maxHP.FinalValue;
    public float MaxMP => _maxMP.FinalValue;
    public float Armor => _armor.FinalValue;
    public float MagicResistance => _magicResistance.FinalValue;
    public float AttackDamage => _attackDamage.FinalValue;
    public float AbilityPower => _abilityPower.FinalValue;
    public float AttackSpeed => _attackSpeed.FinalValue;
    public float CriticalProbability => _criticalProbability.FinalValue;
    public float CriticalDamage => _criticalDamage.FinalValue;
    public float MoveSpeed => _moveSpeed.FinalValue;
    public float Stamina => _stamina.FinalValue;
    public float IncreasedDamage => _increasedDamage.FinalValue;
    public float Drain => _drain.FinalValue;
    public float Range => _range.FinalValue;
    public float CurrentHP { get; private set; }
    public float CurrentMP { get; private set; }



    // ETC Stats
    //public float Condition = 100.0f;
    //public float Satisfaction = 100.0f;

    // Dictionary
    public Dictionary<ECharacterStatType, Stat> _statDict { get; private set; } = new();


    public CharacterStat(CharacterStatScriptableObject so)
    {
        _statDict.Add(ECharacterStatType.MaxHP, _maxHP = new Stat(so.MaxHP));
        _statDict.Add(ECharacterStatType.MaxMP, _maxMP = new Stat(so.MaxMP));
        _statDict.Add(ECharacterStatType.Armor, _armor = new Stat(so.Armor));
        _statDict.Add(ECharacterStatType.MagicResistance, _magicResistance = new Stat(so.MagicResistance));
        _statDict.Add(ECharacterStatType.AttackDamage, _attackDamage = new Stat(so.AttackDamage));
        _statDict.Add(ECharacterStatType.AbilityPower, _abilityPower = new Stat(so.AbilityPower));
        _statDict.Add(ECharacterStatType.AttackSpeed, _attackSpeed = new Stat(so.AttackSpeed));
        _statDict.Add(ECharacterStatType.CriticalProbability, _criticalProbability = new Stat(so.CriticalProbability));
        _statDict.Add(ECharacterStatType.CriticalDamage, _criticalDamage = new Stat(so.CriticalDamage));
        _statDict.Add(ECharacterStatType.MoveSpeed, _moveSpeed = new Stat(so.MoveSpeed));
        _statDict.Add(ECharacterStatType.Stamina, _stamina = new Stat(so.Stamina));
        _statDict.Add(ECharacterStatType.IncreasedDamage, _increasedDamage = new Stat(so.IncreasedDamage));
        _statDict.Add(ECharacterStatType.Drain, _drain = new Stat(so.Drain));
        _statDict.Add(ECharacterStatType.Range, _range = new Stat(so.Range));

        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
    }
}
