using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    // 직렬화
    public SerializableDictionary<string, GameObject> ManagerDictionary = new SerializableDictionary<string, GameObject>();

    // 기타
    private Dictionary<string, IManagerInterface> _managerInterfaceDict = new();
    private IManagerInterface _currentManagerInterface;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InitManagerInterfaceDict();

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
                Instantiate(ManagerDictionary.Dict[DefineClass.MngDictKey_BattleManager]);
                break;
            case EGameState.Room:
                break;
            case EGameState.Result:
                break;
            default:
                break;
        }


        EventBus.Publish(gameState);
    }

    public GameObject GetManagerObject(string key)
    {
        if (ManagerDictionary.Dict.ContainsKey(key)) return ManagerDictionary.Dict[key];

        return null;
    }

    public GameObject GetManagerInterface(string key)
    {
        if (_managerInterfaceDict.ContainsKey(key)) return ManagerDictionary.Dict[key];

        return null;
    }

    private void InitManagerInterfaceDict()
    {
        foreach (var pair in ManagerDictionary.Dict)
        {
            if (pair.Value.TryGetComponent<IManagerInterface>(out IManagerInterface managerInterface))
                _managerInterfaceDict.Add(pair.Key, managerInterface);
        }
    }
}
