using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPMPUISpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject AllyHPMPBarObject;
    [SerializeField]
    private GameObject EnemyHPMPBarObject;

    private List<Character> _characters;

    public void SpawnUI(List<Character> characters)
    {
        _characters = characters;

        foreach (Character character in _characters) 
        {
            if (character.IsPlayerTeam)
                Instantiate(AllyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character);
            else
                Instantiate(EnemyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character);
        }
    }
}
