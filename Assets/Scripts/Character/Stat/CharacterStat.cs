using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStat
{
    // Character
    private Character _character;

    // StatHandler
    public StatHandler StatHandler { get; private set; }

    // Battle Stats ( Private )
    private Stat _maxHP;
    private Stat _maxMP;
    private Stat _armor;
    private Stat _armorPenetration_Flat;
    private Stat _armorPenetration_Percent;
    private Stat _magicResistance;
    private Stat _magicResistancePenetration_Flat;
    private Stat _magicResistancePenetration_Percent;
    private Stat _attackDamage;
    private Stat _abilityPower;
    private Stat _attackSpeed;
    private Stat _criticalProbability;
    private Stat _criticalDamage;
    private Stat _moveSpeed;
    private Stat _stamina;
    private Stat _drain;
    private Stat _range;

    // Special Stats ( Private )
    private Stat _regenHPWhenHitting;
    private Stat _regenMPWhenHitting;
    private Stat _extraDamageWhenHitting_AD;
    private Stat _extraDamageWhenHitting_AP;
    private Stat _increaseShieldQuantity;

    // Battle Stats ( Public )
    public float MaxHP => _maxHP.FinalValue;
    public float MaxMP => _maxMP.FinalValue;
    public float Armor => _armor.FinalValue;
    public float ArmorPenetration_Flat => _armorPenetration_Flat.FinalValue;
    public float ArmorPenetration_Percent => _armorPenetration_Percent.FinalValue;
    public float MagicResistance => _magicResistance.FinalValue;
    public float MagicResistancePenetration_Flat => _magicResistancePenetration_Flat.FinalValue;
    public float MagicResistancePenetration_Percent => _magicResistancePenetration_Percent.FinalValue;
    public float AttackDamage => _attackDamage.FinalValue;
    public float AbilityPower => _abilityPower.FinalValue;
    public float AttackSpeed => _attackSpeed.FinalValue;
    public float CriticalProbability => _criticalProbability.FinalValue;
    public float CriticalDamage => _criticalDamage.FinalValue;
    public float MoveSpeed => _moveSpeed.FinalValue;
    public float Stamina => _stamina.FinalValue;
    public float Drain => _drain.FinalValue;
    public float Range => _range.FinalValue;

    // Special Stats ( Public )
    public float RegenHPWhenHitting => _regenHPWhenHitting.FinalValue;
    public float RegenMPWhenHitting => _regenMPWhenHitting.FinalValue;
    public float ExtraDamageWhenHitting_AD => _extraDamageWhenHitting_AD.FinalValue;
    public float ExtraDamageWhenHitting_AP => _extraDamageWhenHitting_AP.FinalValue;
    public float IncreaseShieldQuantity => _increaseShieldQuantity.FinalValue;


    // ETC Stats
    //public float Condition = 100.0f;
    //public float Satisfaction = 100.0f;

    // Dictionary
    public Dictionary<ECharacterStatType, Stat> _statDict { get; private set; } = new();


    public CharacterStat(Character character, CharacterStatScriptableObject so)
    {
        _character = character;

        // HP, MP
        _statDict.Add(ECharacterStatType.MaxHP, _maxHP = new Stat(so.MaxHP));
        _statDict.Add(ECharacterStatType.MaxMP, _maxMP = new Stat(so.MaxMP));

        // 방어, 마저
        _statDict.Add(ECharacterStatType.Armor, _armor = new Stat(so.Armor));
        _statDict.Add(ECharacterStatType.ArmorPenetration_Flat, 
            _armorPenetration_Flat = new Stat(so.ArmorPenetration_Flat));
        _statDict.Add(ECharacterStatType.ArmorPenetration_Percent, 
            _armorPenetration_Percent = new Stat(so.ArmorPenetration_Percent));
        _statDict.Add(ECharacterStatType.MagicResistance, _magicResistance = new Stat(so.MagicResistance));
        _statDict.Add(ECharacterStatType.MagicResistancePenetration_Flat, 
            _magicResistancePenetration_Flat = new Stat(so.MagicResistancePenetration_Flat));
        _statDict.Add(ECharacterStatType.MagicResistancePenetration_Percent, 
            _magicResistancePenetration_Percent = new Stat(so.MagicResistancePenetration_Percent));

        // 공격
        _statDict.Add(ECharacterStatType.AttackDamage, _attackDamage = new Stat(so.AttackDamage));
        _statDict.Add(ECharacterStatType.AbilityPower, _abilityPower = new Stat(so.AbilityPower));
        _statDict.Add(ECharacterStatType.AttackSpeed, _attackSpeed = new Stat(so.AttackSpeed));
        _statDict.Add(ECharacterStatType.CriticalProbability, _criticalProbability = new Stat(so.CriticalProbability));
        _statDict.Add(ECharacterStatType.CriticalDamage, _criticalDamage = new Stat(so.CriticalDamage));
        _statDict.Add(ECharacterStatType.Range, _range = new Stat(so.Range));

        // 유틸리티
        _statDict.Add(ECharacterStatType.MoveSpeed, _moveSpeed = new Stat(so.MoveSpeed));
        _statDict.Add(ECharacterStatType.Stamina, _stamina = new Stat(so.Stamina));
        _statDict.Add(ECharacterStatType.Drain, _drain = new Stat(so.Drain));

        // 추가 스탯
        _statDict.Add(ECharacterStatType.RegenHPWhenHitting, _regenHPWhenHitting = new Stat(so.RegenMPWhenHitting));
        _statDict.Add(ECharacterStatType.RegenMPWhenHitting, _regenMPWhenHitting = new Stat(so.RegenMPWhenHitting));
        _statDict.Add(ECharacterStatType.ExtraDamageWhenHitting_AD, _extraDamageWhenHitting_AD = new Stat(so.ExtraDamageWhenHitting_AD));
        _statDict.Add(ECharacterStatType.ExtraDamageWhenHitting_AP, _extraDamageWhenHitting_AP = new Stat(so.ExtraDamageWhenHitting_AP));
        _statDict.Add(ECharacterStatType.IncreaseShieldQuantity, _increaseShieldQuantity = new Stat(so.IncreaseShieldQuantity));

        this.StatHandler = new StatHandler(character, this);
    }
}
