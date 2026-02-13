using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat_SO", menuName = "ScriptableObjects/SkillDataScriptableObject/Stat")]
public class Stat_SO : BaseSkillDataScriptableObject, ISkillStatSO
{
    private Dictionary<ECharacterStatType, float> _applyStatDict = new Dictionary<ECharacterStatType, float>();

    [Header("Stat")]
    public float MaxHP;
    public float MaxMP;
    public float Armor;
    public float ArmorPenetration_Flat;
    public float ArmorPenetration_Percent;
    public float MagicResistance;
    public float MagicResistancePenetration_Flat;
    public float MagicResistancePenetration_Percent;
    public float AttackDamage;
    public float AbilityPower;
    public float AttackSpeed;
    public float CriticalProbability;
    public float CriticalDamage;
    public float MoveSpeed;
    public float Stamina;
    public float Drain;
    public float Range;
    public float RegenHPWhenHitting;
    public float RegenMPWhenHitting;
    public float ExtraDamageWhenHitting_AD;
    public float ExtraDamageWhenHitting_AP;
    public float IncreaseShieldQuantity;

    [Header("ETC")]
    public EStatApplyType StatApplyType;
    public EStackType StackType;
    public float During;
    public int MaxStack;



    public virtual Dictionary<ECharacterStatType, float> GetApplyStatDict()
    {
        _applyStatDict.Add(ECharacterStatType.MaxHP, MaxHP);
        _applyStatDict.Add(ECharacterStatType.MaxMP, MaxMP);
        _applyStatDict.Add(ECharacterStatType.Armor, Armor);
        _applyStatDict.Add(ECharacterStatType.ArmorPenetration_Flat, ArmorPenetration_Flat);
        _applyStatDict.Add(ECharacterStatType.ArmorPenetration_Percent, ArmorPenetration_Percent);
        _applyStatDict.Add(ECharacterStatType.MagicResistance, MagicResistance);
        _applyStatDict.Add(ECharacterStatType.MagicResistancePenetration_Flat, MagicResistancePenetration_Flat);
        _applyStatDict.Add(ECharacterStatType.MagicResistancePenetration_Percent, MagicResistancePenetration_Percent);
        _applyStatDict.Add(ECharacterStatType.AttackDamage, AttackDamage);
        _applyStatDict.Add(ECharacterStatType.AbilityPower, AbilityPower);
        _applyStatDict.Add(ECharacterStatType.AttackSpeed, AttackSpeed);
        _applyStatDict.Add(ECharacterStatType.CriticalProbability, CriticalProbability);
        _applyStatDict.Add(ECharacterStatType.CriticalDamage, CriticalDamage);
        _applyStatDict.Add(ECharacterStatType.MoveSpeed, MoveSpeed);
        _applyStatDict.Add(ECharacterStatType.Stamina, Stamina);
        _applyStatDict.Add(ECharacterStatType.Drain, Drain);
        _applyStatDict.Add(ECharacterStatType.Range, Range);
        _applyStatDict.Add(ECharacterStatType.RegenHPWhenHitting, RegenHPWhenHitting);
        _applyStatDict.Add(ECharacterStatType.RegenMPWhenHitting, RegenMPWhenHitting);
        _applyStatDict.Add(ECharacterStatType.ExtraDamageWhenHitting_AD, ExtraDamageWhenHitting_AD);
        _applyStatDict.Add(ECharacterStatType.ExtraDamageWhenHitting_AP, ExtraDamageWhenHitting_AP);
        _applyStatDict.Add(ECharacterStatType.IncreaseShieldQuantity, IncreaseShieldQuantity);

        return _applyStatDict;
    }

    public int GetMaxStack() { return MaxStack; }

    public EStatApplyType GetStatApplyType() { return StatApplyType; }

    public float GetDuring() { return During; }

    public EStackType GetStackType() { return StackType; }
}
