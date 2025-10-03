using System.Collections;
using System.Collections.Generic;

public class StatHandler
{
    private Character _character;
    private CharacterStat _stat;

    public float CurrentHP { get; private set; }
    public float CurrentMP { get; private set; }


    public StatHandler(Character character, CharacterStat stat)
    {
        _character = character;
        _stat = stat;

        CurrentHP = _stat.MaxHP;
        CurrentMP = 0.0f;
    }

    // 캐릭터 체력, 마나 관련
    public float TakeDamage(float damage, bool isAD = true)
    {
        ECharacterStatType damageType = isAD ? ECharacterStatType.AttackDamage : ECharacterStatType.AbilityPower;
        DamageModifer damageModifer = new DamageModifer(_stat, damageType);

        CurrentHP -= damageModifer.Damage();

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

    // 코루틴
    private IEnumerator ResetApplyStat(ECharacterStatType statType, StatModifier modifier, float during)
    {
        yield return YieldCache.WaitForSeconds(during);
        _stat._statDict[statType].RemoveModifier(modifier);
    }

}
