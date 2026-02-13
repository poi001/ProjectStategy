using UnityEngine;
using System.Collections;

public abstract class ActiveSkillBase : ISkill
{
    protected Character character;

    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Sprite Icon { get; protected set; }


    public ActiveSkillBase()
    {
    }

    public abstract IEnumerator StartBattleScene();
    public abstract void EndBattleScene();
    public abstract void Equip(Character character);
    public abstract void Unequip();
    public abstract void ActiveSkill();
    public abstract void DeactiveSkill();
}
