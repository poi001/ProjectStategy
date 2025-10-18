using System.Collections.Generic;
using UnityEngine;

public class HPMPUICanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject AllyHPMPBarObject;
    [SerializeField]
    private GameObject EnemyHPMPBarObject;


    public void SpawnAllyHPMPBarUI((GameObject, Character)[] characters)
    {
        foreach (var character in characters) 
        {
            if (character.Item2 != null)
            {
                Instantiate(AllyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character.Item2);
            }
        }
    }

    public void SpawnEnemyHPMPBarUI((GameObject, Character)[] characters)
    {
        foreach ((GameObject, Character) character in characters)
        {
            Instantiate(EnemyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character.Item2);
        }
    }
}
