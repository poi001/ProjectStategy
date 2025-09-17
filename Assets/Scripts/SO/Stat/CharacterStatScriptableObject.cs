using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fileName : 생성되는 에셋의 이름
//menuName: 에셋을 생성하는 메뉴의 이름.  "/" 를 넣으면 경로가 추가.
//order : 메뉴 중에서 몇 번째 위치에 표시될지 정하는 값.값이 클 수록 마지막에 표기.
[CreateAssetMenu(fileName = "StatSO", menuName = "ScriptableObjects/SkillSO", order = 1)]
public class CharacterStatScriptableObject : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;

    [Header("Battle Stats")]
    public float MaxHP;
    public float MaxMP;
    public float Armor;
    public float MagicResistance;
    public float AttackDamage;
    public float AbilityPower;
    public float AttackSpeed;
    public float CriticalProbability;
    public float CriticalDamage;
    public float MoveSpeed;
    public float Stamina;
    public float IncreasedDamage;
    public float Drain;
    public float Range;
}
