using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Passive_Stat : PassiveBase
{
    protected Dictionary<ECharacterStatType, float> statDict = new Dictionary<ECharacterStatType, float>();
    protected Dictionary<ECharacterStatType, StatModifier> modiDict = new Dictionary<ECharacterStatType, StatModifier>();
    protected ISkillStatSO interfaceSO;


    public Passive_Stat() : base()
    {
    }

    public override IEnumerator StartBattleScene()
    {
        yield return base.StartBattleScene();

        interfaceSO = so as ISkillStatSO;
        statDict = interfaceSO.GetApplyStatDict();

        foreach (var kvp in statDict)
        {
            ECharacterStatType type = kvp.Key;

            if (statDict[type] == 0.0f) 
                statDict.Remove(type);
        }

        yield return new WaitUntil(() => { return statDict != null; });
    }
}
