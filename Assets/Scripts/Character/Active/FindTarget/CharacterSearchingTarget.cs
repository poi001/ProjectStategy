using System;
using UnityEngine;

public class CharacterSearchingTarget
{
    private Character _character;
    private Action _findTargtFunc;
    private float _timer = 1.0f;


    public CharacterSearchingTarget(Character character)
    {
        _character = character;

        ChangeSearchingTarget(BasicFindTarget);
        character.OnUpdate += UpdateFindTarget;
    }

    public void ChangeSearchingTarget(Action func = null)
    {
        if (func == null) ChangeSearchingTarget(BasicFindTarget);
        else _findTargtFunc = func;
    }

    private void UpdateFindTarget()
    {
        if(_timer < 0.3f)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer = 0.0f;
            _findTargtFunc?.Invoke();
        }
    }

    private void BasicFindTarget()
    {
        if (_character.IsPlayerTeam) _character.Target = BattleManager.Instance.GetEnemyCharacters(_character)[0].Item2;
        else _character.Target = BattleManager.Instance.GetAllyCharacters(_character)[0].Item2;
    }
}
