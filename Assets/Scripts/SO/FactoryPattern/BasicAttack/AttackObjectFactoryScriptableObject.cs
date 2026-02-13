using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFactoryScriptableObject", menuName = "ScriptableObjects/FactoryScriptableObjectScript", order = 0)]
public class AttackObjectFactoryScriptableObject : ScriptableObject, IAttackObjectFactory
{
    public GameObject AttackObjectPrefab;

    public IAttackObject Create(Vector3 pos)
    {
        GameObject obj = Instantiate(AttackObjectPrefab, pos, Quaternion.identity);

        return obj.GetComponent<AttackObject>() as IAttackObject;
    }
}
