using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFactoryScriptableObject", menuName = "ScriptableObjects/FactoryScriptableObjectScript", order = 0)]
public class AttackObjectFactoryScriptableObject : ScriptableObject, IAttackObjectFactory
{
    public GameObject AttackObjectPrefab;
    public GameObject PassiveObjectPrefab;
    public GameObject SkillObjectPrefab;
    public GameObject UltObjectPrefab;


    public IAttackObject Create(EAttackType type, Vector3 pos)
    {
        GameObject obj = null;

        switch (type)
        {
            case EAttackType.BasicAttack:
                obj = Instantiate(AttackObjectPrefab, pos, Quaternion.identity);
                break;
            case EAttackType.Passive:
                obj = Instantiate(PassiveObjectPrefab, pos, Quaternion.identity);
                break;
            case EAttackType.Skill:
                obj = Instantiate(SkillObjectPrefab, pos, Quaternion.identity);
                break;
            default:
                break;
        }

        return obj.GetComponent<AttackObject>() as IAttackObject;
    }
}
