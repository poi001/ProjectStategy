using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler
{
    [SerializeField]
    private CharacterStatScriptableObject _so;
    public CharacterStat Stat { get; private set; }
    private Character _character;

    public void InitStatHandler(Character character)
    {
        _character = character;
        Stat = new CharacterStat(_so);
    }

    public void ApplyStat(ECharacterStatType statType, StatModifier modifier)
    {
        Stat._statDict[statType].AddModifier(modifier);
    }

    public void ApplyStat(ECharacterStatType statType, StatModifier modifier, float during, string key = null)
    {
        Stat._statDict[statType].AddModifier(modifier);
        CoroutineManager.Instance.StartManagedCoroutine(ResetApplyStat(statType, modifier, during), key);
    }

    public void DeleteApplyStat(ECharacterStatType statType, StatModifier modifier)
    {
        Stat._statDict[statType].RemoveModifier(modifier);
    }

    public void DeleteApplyStat(ECharacterStatType statType, StatModifier modifier, string key)
    {
        CoroutineManager.Instance.StopManagedCoroutine(key);
    }

    private IEnumerator ResetApplyStat(ECharacterStatType statType, StatModifier modifier, float during)
    {
        yield return YieldCache.WaitForSeconds(during);
        Stat._statDict[statType].RemoveModifier(modifier);
    }
}
