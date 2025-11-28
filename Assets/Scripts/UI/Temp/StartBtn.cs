using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartBtn : ButtonBase
{
    [SerializeField] private List<GameObject> _member;
    [SerializeField] private List<GameObject> _enemy;


    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        PlayerDataScriptableObject.Instance.Memebers = _member.ToArray();
        PlayerDataScriptableObject.Instance.EnemyMemebers = _enemy.ToArray();
        LoadManager.Instance.ChangeGameState(EGameState.Battle);
    }
}
