

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
