using UnityEngine;

public class ActiveSkillBase : ISkill
{
    protected Character owner;



    public ActiveSkillBase(Character owner)
    {
        this.owner = owner;
    }

    public virtual void ActiveSkill()
    {

    }
}
