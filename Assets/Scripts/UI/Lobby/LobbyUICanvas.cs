using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUICanvas : UIBase
{
    // Left Panel
    [SerializeField] private LobbyLeftPanel _lobbyLeftPanel;

    // Top Panel
    [SerializeField] private LobbyTopPanel _lobbyTopPanel;

    // Bottom Panel
    [SerializeField] private LobbyBottomPanel _lobbyBottomPanel;

    // µ¨¸®°ÔÀÌÆ®
    public Action OnPushGameButton;
    public Action OnPushTeamSettingButton;
    public Action OnPushQuestButton;
    public Action OnPushStoreButton;
    public Action OnPushOptionButton;


    public override IEnumerator Init()
    {
        EventBus.Register(EGameState.Lobby, EventBusRegistDelegate);
        InitDelegate();

        yield return new WaitUntil(() => OnPushGameButton != null);
        yield return new WaitUntil(() => OnPushTeamSettingButton != null);
        yield return new WaitUntil(() => OnPushQuestButton != null);
        yield return new WaitUntil(() => OnPushStoreButton != null);
        yield return new WaitUntil(() => OnPushOptionButton != null);
    }

    public override void OnDisableFun()
    {
        //OnPushGameButton = null;
        //OnPushTeamSettingButton = null;
        //OnPushQuestButton = null;
        //OnPushStoreButton = null;
        //OnPushOptionButton = null;
    }

    private void EventBusRegistDelegate()
    {
        UIManager.Instance.ShowUI(DefineClass.UI_LobbyUICanvas);
    }

    private void InitDelegate()
    {
        OnPushGameButton += _lobbyBottomPanel.ChangeGameImage;
        OnPushTeamSettingButton += _lobbyBottomPanel.ChangeTeamSettingImage;
        OnPushQuestButton += _lobbyBottomPanel.ChangeQuestImage;
        OnPushStoreButton += _lobbyBottomPanel.ChangeStoreImage;
        OnPushOptionButton += _lobbyBottomPanel.ChangeOptionImage;
    }

    public LobbyLeftPanel GetLobbyLeftPanel() {  return _lobbyLeftPanel; }
    public LobbyTopPanel GetLobbyTopPanel() { return _lobbyTopPanel; }
    public LobbyBottomPanel GetLobbyBottomPanel() { return _lobbyBottomPanel; }
}
