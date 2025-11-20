

public abstract class PassiveBase : IPassive
{
    protected Character owner;


    public PassiveBase(Character owner)
    {
        this.owner = owner;
    }

    public abstract void ApplyPassive();
}
