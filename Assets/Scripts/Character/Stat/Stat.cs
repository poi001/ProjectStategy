using System.Collections.Generic;
using System.Text;

public class Stat
{
    private readonly List<StatModifier> _modifiers = new();

    public Stat(float baseValue)
    {
        BaseValue = baseValue;
    }

    public float BaseValue { get; set; }
    public float FinalValue => CalculateFinalValue();

    public void AddModifier(StatModifier modifier_) => _modifiers.Add(modifier_);
    public void RemoveModifier(StatModifier modifier_) => _modifiers.Remove(modifier_);
    public void RemoveAllModifier(StatModifier modifier_) => _modifiers.RemoveAll(x => x == modifier_);
    public void ClearModifier() => _modifiers.Clear();
    public List<StatModifier> GetModifierList() => _modifiers;

    private float CalculateFinalValue()
    {
        float flatSum = 0f;
        float percentMul = 1f;

        StatModifier constMod = _modifiers.Find(m => m.Type == EStatApplyType.Const);
        if (constMod != null) return constMod.Value;

        foreach (var mod in _modifiers)
        {
            switch (mod.Type)
            {
                case EStatApplyType.Flat:
                    flatSum += mod.Value;
                    break;
                case EStatApplyType.Percent:
                    percentMul *= 1 + (mod.Value / 100f);
                    break;
            }
        }

        return (BaseValue + flatSum) * percentMul;
    }

    //public string GetCalculationString()
    //{
    //    StatModifier constMod = _modifiers.Find(m => m.Type == StatType.Const);
    //    if (constMod != null) return $"{BaseValue} const = {constMod.Value}";

    //    StringBuilder sb = new StringBuilder();
    //    sb.Append(BaseValue);

    //    foreach (var mod in _modifiers)
    //    {
    //        if (mod.Type == StatType.Flat)
    //            sb.Append($" + {mod.Value}");
    //    }
    //    foreach (var mod in _modifiers)
    //    {
    //        if (mod.Type == StatType.Percent)
    //            sb.Append($" ¡¿ (1 + {mod.Value / 100} )");
    //    }

    //    sb.Append($" = {FinalValue}");

    //    return sb.ToString();
    //}
}
