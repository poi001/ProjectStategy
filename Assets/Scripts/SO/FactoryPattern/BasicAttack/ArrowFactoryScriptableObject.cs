using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFactoryScriptableObject", menuName = "ScriptableObjects/FactoryScriptableObjectScript", order = 0)]
public class ArrowFactoryScriptableObject : ScriptableObject, IAttackObjectFactory
{
    public GameObject arrowPrefab;


    public IAttackObject Create(Vector3 pos)
    {
        var obj = Instantiate(arrowPrefab, pos, Quaternion.identity);
        return obj.GetComponent<AttackObject>() as IAttackObject;
    }
}
