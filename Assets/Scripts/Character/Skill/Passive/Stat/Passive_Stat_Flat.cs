using UnityEngine;
using System.Collections;

public class Passive_Stat_Flat : Passive_Stat
{
    private EStatApplyType _applyType;

    public Passive_Stat_Flat() : base()
    {
    }

    public override void ActiveSkill()
    {
        foreach (var kvp in statDict)
        {
            ECharacterStatType type = kvp.Key;

            if (!modiDict.TryGetValue(type, out StatModifier modi))
            {
                modiDict.Add(type, modi = new StatModifier(statDict[type], _applyType));
                character.Stats.StatHandler.ApplyStat(type, modi);
            }
        }
    }

    public override void DeactiveSkill()
    {
        foreach (var kvp in modiDict)
            character.Stats.StatHandler.DeleteApplyStat(kvp.Key, kvp.Value);

        modiDict.Clear();
    }

    public override IEnumerator StartBattleScene()
    {
        yield return base.StartBattleScene();
        _applyType = interfaceSO.GetStatApplyType();

        // 코드가 비교적 간단해 yield return의 조건을 지정하지 않음
        yield return null;
    }

    public override void EndBattleScene()
    {

    }
}
