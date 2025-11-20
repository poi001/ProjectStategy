using System.Collections;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    public EGameState CurrentGameState = EGameState.None;


    private void Start()
    {
        StartCoroutine(InitManager.Instance.Init());
    }

    public void OnManagersInitialized()
    {
        LoadManager.Instance.ChangeGameState(EGameState.Lobby);
    }


}
