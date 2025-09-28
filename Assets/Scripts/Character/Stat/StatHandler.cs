using System.Collections;
using UnityEngine.TextCore.Text;

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

    public float TakeDamaged(float value)
    {
        CurrentHP -= value;

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

    public void ApplyStat(ECharacterStatType statType, StatModifier modifier)
    {
        _stat._statDict[statType].AddModifier(modifier);
    }

    public void ApplyStat(ECharacterStatType statType, StatModifier modifier, float during, string key = null)
    {
        _stat._statDict[statType].AddModifier(modifier);
        CoroutineManager.Instance.StartManagedCoroutine(ResetApplyStat(statType, modifier, during), key);
    }

    public void DeleteApplyStat(ECharacterStatType statType, StatModifier modifier)
    {
        _stat._statDict[statType].RemoveModifier(modifier);
    }

    public void DeleteApplyStat(ECharacterStatType statType, StatModifier modifier, string key)
    {
        CoroutineManager.Instance.StopManagedCoroutine(key);
    }

    private IEnumerator ResetApplyStat(ECharacterStatType statType, StatModifier modifier, float during)
    {
        yield return YieldCache.WaitForSeconds(during);
        _stat._statDict[statType].RemoveModifier(modifier);
    }
}
