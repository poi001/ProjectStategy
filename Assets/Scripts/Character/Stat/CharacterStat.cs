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
        SetupStat(_maxHP, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_maxMP, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_armor, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_magicResistance, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_attackDamage, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_abilityPower, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_attackSpeed, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_criticalProbability, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_criticalDamage, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_moveSpeed, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_stamina, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_increasedDamage, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_drain, so.MaxHP, ECharacterStatType.MaxHP);
        SetupStat(_range, so.MaxHP, ECharacterStatType.MaxHP);

        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
    }

    private void SetupStat(Stat stat, float value, ECharacterStatType statType)
    {
        stat = new Stat(value);
        _statDict.Add(statType, stat);
    }
}
