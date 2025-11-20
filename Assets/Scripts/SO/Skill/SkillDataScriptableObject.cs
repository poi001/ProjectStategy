using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataScriptableObject", menuName = "ScriptableObjects/SkillDataScriptableObject", order = 2)]
public class SkillDataScriptableObject : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public Sprite Sprite;

    [HideInInspector]
    public ISkill SkillBase;
}
