using UnityEngine;

//fileName : 생성되는 에셋의 이름
//menuName: 에셋을 생성하는 메뉴의 이름.  "/" 를 넣으면 경로가 추가.
//order : 메뉴 중에서 몇 번째 위치에 표시될지 정하는 값.값이 클 수록 마지막에 표기.
[CreateAssetMenu(fileName = "CharacterStatScriptableObject", menuName = "ScriptableObjects/CharacterStatScriptableObject", order = 1)]
public class CharacterStatScriptableObject : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;

    [Header("CharacterSetting")]
    public ECharacterType CharacterType;
    public EWeaponType WeaponType;

    [Header("Battle Stats")]
    public float MaxHP;
    public float MaxMP;
    public float Armor;
    public float ArmorPenetration_Flat;
    public float ArmorPenetration_Percent;
    public float MagicResistance;
    public float MagicResistancePenetration_Flat;
    public float MagicResistancePenetration_Percent;
    public float AttackDamage;
    public float AbilityPower;
    public float AttackSpeed;
    public float CriticalProbability;
    public float CriticalDamage;
    public float MoveSpeed;
    public float Stamina;
    public float Drain;
    public float Range;

    [Header("Battle StatsExtra(Special Stats)")]
    public float RegenHPWhenHitting = 0.0f;             // 타격당 체력회복
    public float RegenMPWhenHitting = 5.0f;             // 타격당 마나회복
    public float ExtraDamageWhenHitting_AD = 0.0f;      // 타격당 AD피해
    public float ExtraDamageWhenHitting_AP = 0.0f;      // 타격당 AP피해
    public float IncreaseShieldQuantity = 1.0f;         // 추가 쉴드( % )



    [Header("Object Factory")]
    public ScriptableObject BasicAttackFactorySO;
    public IAttackObjectFactory BasicAttackFactory => BasicAttackFactorySO as IAttackObjectFactory;
}
