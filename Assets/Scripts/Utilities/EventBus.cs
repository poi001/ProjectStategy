using System.Collections.Generic;
using UnityEngine.Events;


public static class EventBus
{
    public static readonly Dictionary<EGameState, UnityEvent> Events = new();

    // 이벤트 등록
    public static void Register(EGameState gameState, UnityAction action)
    {
        if (!Events.ContainsKey(gameState))
            Events.Add(gameState, new UnityEvent());

        Events[gameState].AddListener(action);
    }

    // 이벤트 해제
    public static void Unregister(EGameState gameState, UnityAction action)
    {
        if (Events.TryGetValue(gameState, out UnityEvent @event))
        {
            @event.RemoveListener(action);
        }
    }

    // 이벤트 실행
    public static void Publish(EGameState gameState)
    {
        if (Events.TryGetValue(gameState, out UnityEvent @event))
        {
            UIManager.Instance.HideAllUI();
            @event.Invoke();
        }
    }
}