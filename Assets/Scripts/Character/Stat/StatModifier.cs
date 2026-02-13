

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class StatModifier
{
    public float Value { get; }
    public EStatApplyType Type { get; }

    public StatModifier(float value, EStatApplyType type)
    {
        Value = value;
        Type = type;
    }
}

// 반복적으로 사용해야 할 스탯 변화들은 이 클래스를 사용함
public static class StatModifierCache
{
    private static readonly Dictionary<int, StatModifier> StatModifierBasket_Dict =
        new Dictionary<int, StatModifier>();


    public static StatModifier CreateStatModifier(int hash_Key, EStatApplyType applyType, float value)
    {
        StatModifier modi;
        if (!StatModifierBasket_Dict.TryGetValue(hash_Key, out modi))
            StatModifierBasket_Dict.Add(hash_Key, modi = new StatModifier(value, applyType));
        return modi;
    }
}
