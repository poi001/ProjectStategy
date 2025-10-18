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
        //ChangeGameState(EGameState.Lobby);
        LoadManager.Instance.ChangeGameState(EGameState.Lobby);
    }

    //public void ChangeGameState(EGameState gameState)
    //{
    //    switch (gameState)
    //    {
    //        case EGameState.Bootstrap:
    //            GameStateName = DefineClass.Scene_Bootstrap;
    //            break;
    //        case EGameState.Title:
    //            GameStateName = DefineClass.Scene_Title;
    //            break;
    //        case EGameState.Lobby:
    //            GameStateName = DefineClass.Scene_Lobby;
    //            break;
    //        case EGameState.Battle:
    //            GameStateName = DefineClass.Scene_Battle;
    //            break;
    //        case EGameState.Room:
    //            break;
    //        case EGameState.Result:
    //            break;
    //        default:
    //            break;
    //    }

    //    GameState = gameState;
    //    LoadManager.Instance.LoadScene(GameStateName);
    //    EventBus.Publish(gameState);
    //}


}
