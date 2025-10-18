using UnityEngine;

public class PassiveBase : IPassive
{
    protected Character owner;


    public PassiveBase(Character owner)
    {
        this.owner = owner;
    }

    public virtual void ApplyPassive()
    {

    }
}
