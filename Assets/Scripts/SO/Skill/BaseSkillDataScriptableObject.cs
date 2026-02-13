using UnityEngine;

public class BaseSkillDataScriptableObject : ScriptableObject
{
    [Header("Info")]
    public int ID;
    public string Name;
    public string Description;
    public Sprite Sprite;
    public bool IsInnatePassive;
    public ESkillTierType Tier;

    [HideInInspector]
    public ISkill Skill;
}
