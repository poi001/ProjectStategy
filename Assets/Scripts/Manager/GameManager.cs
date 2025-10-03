using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    public SerializableDictionary<string, GameObject> ManagerDictionary;

    // ±‚≈∏
    private EGameState _state;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // temp
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
                FindIAboutSceneManager(Instantiate(ManagerDictionary.Dict[DefineClass.MngDictKey_BattleManager]));
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

    public GameObject GetManagerObject(string key)
    {
        if (ManagerDictionary.Dict.ContainsKey(key)) return ManagerDictionary.Dict[key];

        return null;
    }

    private void FindIAboutSceneManager(GameObject obj)
    {
        if (obj.TryGetComponent<IAboutSceneManager>(out IAboutSceneManager managerInterface))
        {
            EventBus.Register(managerInterface.State, managerInterface.EnterScene);
        }
    }
}
