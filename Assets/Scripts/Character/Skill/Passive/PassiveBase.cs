using System;
using System.Collections;
using UnityEngine;

public abstract class PassiveBase : ISkill
{
    protected Character character;
    protected BaseSkillDataScriptableObject so;

    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Sprite Icon { get; protected set; }
    public bool IsInnatePassive { get; protected set; }
    public ESkillTierType Tier { get; protected set; }


    public PassiveBase()
    {
    }

    public virtual IEnumerator StartBattleScene()
    {
        if (so != null)
        {
            ID = so.ID;
            Name = so.Name;
            Description = so.Description;
            Icon = so.Sprite;
            IsInnatePassive = so.IsInnatePassive;
            Tier = so.Tier;
        }
        else
        {
            ID = -1;
        }

        yield return new WaitUntil(() =>
        { return ID != -1 
            && !string.IsNullOrEmpty(Name) 
            && !string.IsNullOrEmpty(Description) 
            && Icon != null;
        });
    }
    public abstract void EndBattleScene();

    public void Equip(Character character)
    {
        this.character = character;
    }
    public void Unequip()
    {
        this.character = null;
    }

    public abstract void ActiveSkill();
    public abstract void DeactiveSkill();
}
