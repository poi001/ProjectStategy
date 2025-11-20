using UnityEngine;

[CreateAssetMenu(fileName = "PassiveDataScriptableObject", menuName = "ScriptableObjects/SkillDataScriptableObject", order = 1)]
public class PassiveDataScriptableObject : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public Sprite Sprite;

    [HideInInspector]
    public IPassive Passive;
}
