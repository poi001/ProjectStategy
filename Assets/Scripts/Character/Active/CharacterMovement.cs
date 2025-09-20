using UnityEngine;

public abstract class CharacterMovement
{
    protected Character _character;

    public CharacterMovement(Character character)
    {
        _character = character;
    }

    protected abstract void Movement();

    public void UpdateMovement()
    {
        // 적 위치에 따라, 캐릭터의 좌우 방향을 정해줌
        FlipCharacter();

        // 움직임
        Movement();
    }

    private void FlipCharacter()
    {
        // 플레이어가 오른쪽을 향할 때
        if (_character._dir.x > 0.0f && _character._isFacingLeft)
        {
            _character.Flip(); // 스케일을 반전
        }
        // 플레이어가 왼쪽을 향할 때
        else if (_character._dir.x < 0.0f && !_character._isFacingLeft)
        {
            _character.Flip(); // 스케일을 반전
        }
    }

    protected void MovingToTarget()
    {
        _character._dir = (_character.Target.transform.position - _character.transform.position).normalized;

        _character.transform.position += (Vector3)_character._dir * Time.deltaTime * _character.Stats.MoveSpeed;
        Vector3 pos = _character.transform.position;
        //if (pos.x >= 23.0f) pos.x = 23.0f;
        //if (pos.x <= -23.0f) pos.x = -23.0f;
        //if (pos.y >= 23.0f) pos.y = 23.0f;
        //if (pos.y <= -23.0f) pos.y = -23.0f;
        //_character.transform.position = pos;
    }

    protected void MovingAwayFromtarget()
    {
        _character._dir = (_character.Target.transform.position - _character.transform.position).normalized * -1.0f;

        _character.transform.position += (Vector3)_character._dir * Time.deltaTime * _character.Stats.MoveSpeed;
        Vector3 pos = _character.transform.position;
    }
}
