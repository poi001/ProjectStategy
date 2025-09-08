using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    private EGameState _state;


    private void Start()
    {
        ChangeGameState(EGameState.Title);
    }

    public void ChangeGameState(EGameState gameState)
    {
        switch (gameState)
        {
            case EGameState.Title:
                break;
            case EGameState.Lobby:
                break;
            case EGameState.Battle:
                break;
            case EGameState.Room:
                break;
            case EGameState.Result:
                break;
            default:
                break;
        }

        _state = gameState;
        EventBus.Publish(gameState);
    }


}
