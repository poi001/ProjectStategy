using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovement : MonoBehaviour
{
    private Character _character;
    private Vector2 _targetPos;

     
    public void InitMovement(Character character)
    {
        _character = character;

        StartCoroutine(FindToTarget_Coroutine(0.15f));
        _character.StateMachine.ChanageState(_character.StateMachine.moveState);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(_character.transform.position, _targetPos, Time.deltaTime);
    }

    IEnumerator FindToTarget_Coroutine(float deltaTime)
    {
        while (true)
        {
            if (BattleManager.Instance != null)
            {
                Character character = BattleManager.Instance.GetNearEnemy(_character.IsPlayerTeam, _character.transform.position);
                if (character != null) _targetPos = character.transform.position;
            }

            yield return new WaitForSeconds(deltaTime);
        }
    }
}
