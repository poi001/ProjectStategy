using System.Collections;
using UnityEngine.TextCore.Text;

public class StatHandler
{
    private Character _character;
    private CharacterStat _stat;

    private float _currentHP;
    private float _currentMP;

    public float CurrentHP
    {
        get { return _currentHP; }
        set { _currentHP = value > _stat.MaxHP ? _stat.MaxHP : value; }
    }
    public float CurrentMP
    {
        get { return _currentMP; }
        set { _currentMP = value > _stat.MaxMP ? _stat.MaxMP : value; }
    }


    public StatHandler(Character character, CharacterStat stat)
    {
        _character = character;
        _stat = stat;

        CurrentHP = _stat.MaxHP;
        CurrentMP = 0.0f;

        _character.OnAttack += RegenMana;
    }

    // 캐릭터 체력, 마나 관련
    public float TakeDamage(float damage, CharacterStat stat, EDamageType damageType = EDamageType.AD)
    {
        CurrentHP -= CalcDamage(damage, damageType, stat);

        if (CurrentHP <= 0.0f)
        {
            CurrentHP = 0.0f;
            CharacterDie();
        }

        _character.OnDamaged?.Invoke();

        return CurrentHP;
    }
    public void RegenMana(float value)
    {
        RegenMana_Func(value);
    }
    public void RegenMana()
    {
        RegenMana_Func(_stat.RegenMPWhenHitting);
    }
    private void RegenMana_Func(float value)
    {
        CurrentMP += value;

        if (CurrentMP >= _stat.MaxMP)
        {
            float remainMP = _stat.MaxMP - CurrentMP;
            CurrentMP = remainMP;
            if (CurrentMP >= _stat.MaxMP) CurrentMP -= 1.0f;
            UseMana();
        }

        _character.OnUseMana?.Invoke();
    }
    public void UseMana()
    {
        _character.OnUseMana?.Invoke();
    }
    public void CharacterDie()
    {
        _character.OnDeath?.Invoke();
    }

    // 스탯 적용
    public void ApplyStat(ECharacterStatType statType, StatModifier modifier)
    {
        _stat._statDict[statType].AddModifier(modifier);
    }
    public void ApplyStat(ECharacterStatType statType, StatModifier modifier, float during, string key = null)
    {
        _stat._statDict[statType].AddModifier(modifier);
        CoroutineManager.Instance.StartManagedCoroutine(ResetApplyStat(statType, modifier, during), key);
    }
    public void DeleteApplyStat(ECharacterStatType statType, StatModifier modifier, string key = null)
    {
        if (string.IsNullOrEmpty(key))
            _stat._statDict[statType].RemoveModifier(modifier);
        else
            CoroutineManager.Instance.StopManagedCoroutine(key);
    }
    public void DeleteApplyStat_RemoveAll(ECharacterStatType statType, StatModifier modifier, string key = null)
    {
        if (string.IsNullOrEmpty(key))
            _stat._statDict[statType].RemoveAllModifier(modifier);
        else
            CoroutineManager.Instance.StopManagedCoroutine(key);
    }

    // 대미지 계산
    private float CalcDamage(float damage, EDamageType damageType, CharacterStat stat)
    {
        float resistance = 0.0f;
        float penetration_Flat = 0.0f;
        float penetration_Percent = 0.0f;

        switch (damageType)
        {
            case EDamageType.AD:
                resistance = _stat.Armor;
                penetration_Flat = stat.ArmorPenetration_Flat;
                penetration_Percent = stat.ArmorPenetration_Percent;
                break;
            case EDamageType.AP:
                resistance = _stat.MagicResistance;
                penetration_Flat = stat.MagicResistancePenetration_Flat;
                penetration_Percent = stat.MagicResistancePenetration_Percent;
                break;
            default:
                break;
        }

        float finalArmor = resistance * (1.0f - penetration_Percent * 0.01f) - penetration_Flat;

        return damage * (1.0f / (1.0f + (finalArmor * 0.01f)));
    }

    // 코루틴
    private IEnumerator ResetApplyStat(ECharacterStatType statType, StatModifier modifier, float during)
    {
        yield return YieldCache.WaitForSeconds(during);
        _stat._statDict[statType].RemoveModifier(modifier);
    }

}
