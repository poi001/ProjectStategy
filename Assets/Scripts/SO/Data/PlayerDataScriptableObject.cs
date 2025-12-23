using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataScriptableObject", menuName = "ScriptableObjects/PlayerDataScriptableObject", order = 2)]
public class PlayerDataScriptableObject : ScriptableObjectSingleton<PlayerDataScriptableObject>
{
    [Header("PlayerData")]
    public string PlayerName;
    public int Gold;

    //[Header("PlayerStats")]
    //public float ;
    //public float Gold;

    // 캐릭터
    [HideInInspector]
    public GameObject[] Memebers = new GameObject[DefineClass.NumberOfPlayers];
    [HideInInspector]
    public GameObject[] EnemyMemebers = new GameObject[DefineClass.NumberOfPlayers];

    // 전투 타입
    [HideInInspector]
    public ECombatType[] MemebersCombatType = new ECombatType[DefineClass.NumberOfPlayers];
    [HideInInspector]
    public ECombatType[] EnemyMemebersCombatType = new ECombatType[DefineClass.NumberOfPlayers];

    // 아이템
}
