using UnityEngine;

public class DamageModifer
{
    public float Value { get; }
    public ECharacterStatType Type { get; }

    private float _armorOrMagicResistance;
    private float _penetration_Flat;
    private float _penetration_Percent;

    //init으로 바꾸기
    public DamageModifer(CharacterStat damagedStat, ECharacterStatType type)
    {
        Type = type;

        if (type == ECharacterStatType.AttackDamage)
        {
            Value = damagedStat.AttackDamage;
            _armorOrMagicResistance = damagedStat.Armor;
            _penetration_Flat = damagedStat.ArmorPenetration_Flat;
            _penetration_Percent = damagedStat.ArmorPenetration_Percent;
        }
        else
        {
            Value = damagedStat.AbilityPower;
            _armorOrMagicResistance = damagedStat.MagicResistance;
            _penetration_Flat = damagedStat.MagicResistancePenetration_Flat;
            _penetration_Percent = damagedStat.MagicResistancePenetration_Percent;
        }
    }

    public float Damage()
    {
        float finalArmor = _armorOrMagicResistance * (1.0f - _penetration_Percent * 0.01f) - _penetration_Flat;

        return Value * (1.0f / (1.0f + (finalArmor * 0.01f)));
    }
}
