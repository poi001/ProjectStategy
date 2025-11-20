using UnityEngine;

public abstract class ActiveSkillBase : ISkill
{
    protected Character owner;
    protected bool isUlt;
    protected bool isUesd = false;


    public ActiveSkillBase(Character owner, bool isUlt)
    {
        this.owner = owner;
        this.isUlt = isUlt;
    }

    public abstract void ActiveSkill();
}
