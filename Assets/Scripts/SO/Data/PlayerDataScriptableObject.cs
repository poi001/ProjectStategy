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

    [HideInInspector]
    public GameObject[] Memebers = new GameObject[DefineClass.NumberOfPlayers];
    // temp
    [HideInInspector]
    public GameObject[] EnemyMemebers = new GameObject[DefineClass.NumberOfPlayers];
}
