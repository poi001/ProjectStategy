using UnityEngine;

public class CharacterSkillData
{
    private Character _character;

    public IPassive Passive { get; private set; }
    public ISkill Skill { get; private set; }
    public ISkill UltSkill { get; private set; }


    public CharacterSkillData(Character character)
    {
        _character = character;

        //_character.OnChangePassive += 
    }

    public void ChangePassive(IPassive newPassive)
    {
        _character.OnChangePassive?.Invoke();


    }

    public void ChangeSkill(ISkill newSkill)
    {
        _character.OnChangeSkill?.Invoke();
    }

    public void ChangeUltSkill(ISkill newUltSkill)
    {
        _character.OnChangeUltSkill?.Invoke();
    }

    //private void ChangePassive(IPassive newPassive)
    //{
    //    _character.OnChangePassive?.Invoke();
    //}

    //private void ChangeSkill(ISkill newSkill)
    //{
    //    _character.OnChangeSkill?.Invoke();
    //}

    //private void ChangeUltSkill(ISkill newUltSkill)
    //{
    //    _character.OnChangeUltSkill?.Invoke();
    //}
}
