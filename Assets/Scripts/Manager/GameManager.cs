using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    // 매니저 오브젝트 ( 직렬화 )
    [SerializeField]
    private GameObject _battleManagerObject;

    // 매니저 스크립트
    private BattleManager _battleManager;

    // 기타
    private EGameState _state;


    private void Start()
    {
        Init();
    }

    private void Init()
    {


        ChangeGameState(EGameState.Battle);
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
