using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive_Stat_Stack : Passive_Stat
{
    private EStatApplyType _applyType;
    private EStackType _stackType;
    private int _maxStack;
    private float _during;
    private int _stack;

    private Action _action;

    public Passive_Stat_Stack() : base()
    {
    }

    public override void ActiveSkill()
    {
        foreach (var kvp in statDict)
        {
            if (_stack == _maxStack) return;

            ECharacterStatType type = kvp.Key;

            if (!modiDict.ContainsKey(type))
                modiDict.Add(type, StatModifierCache.CreateStatModifier(ID, _applyType, statDict[type]));

            character.Stats.StatHandler.ApplyStat(type, modiDict[type]);
        }

        ++_stack;
    }

    public override void DeactiveSkill()
    {
        foreach (var kvp in modiDict)
            character.Stats.StatHandler.DeleteApplyStat_RemoveAll(kvp.Key, kvp.Value);

        _stack = 0;
        modiDict.Clear();
    }

    public override IEnumerator StartBattleScene()
    {
        yield return base.StartBattleScene();
        _applyType = interfaceSO.GetStatApplyType();
        _stackType = interfaceSO.GetStackType();
        _maxStack = interfaceSO.GetMaxStack();
        _during = interfaceSO.GetDuring();

        _action = GetAction();
        _action += ActiveSkill;

        // 코드가 비교적 간단해 yield return의 조건을 지정하지 않음
        yield return null;
    }
    public override void EndBattleScene()
    {
        _action -= ActiveSkill;
    }

    private Action GetAction()
    {
        switch (_stackType)
        {
            case EStackType.Attack:
                return character.OnAttack;

            case EStackType.Damaged:
                return character.OnDamaged;

            case EStackType.Skill:
                return character.OnSkill;

            case EStackType.Move:
                return character.OnMove;

            default:
                return null;
        }
    }
}
