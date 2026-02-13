using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillData
{
    private Character _character;

    public List<ISkill> PassiveList { get; private set; } = new List<ISkill>();
    public ISkill Skill { get; private set; }


    public CharacterSkillData(Character character)
    {
        _character = character;

        //_character.OnChangePassive += 
    }

    public void ChangePassive(ISkill newPassive)
    {
        _character.OnChangePassive?.Invoke();


    }
}
