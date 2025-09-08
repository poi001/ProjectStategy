using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStat : MonoBehaviour
{
    private Character _character;


    public void InitStat(Character character)
    {
        _character = character;
    }
}
