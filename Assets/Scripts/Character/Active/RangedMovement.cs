using UnityEngine;

public class RangedMovement : CharacterMovement
{

    public RangedMovement(Character character) : base(character)
    {

    }

    protected override void Movement()
    {
        // 공격 사거리까지 닿았는지 확인
        if (_character.Stats.Range - _character.Stats.Range * 0.1f >= 
            Vector2.Distance(_character.transform.position, _character.Target.transform.position))
        {
            MovingAwayFromtarget();
        }
        else
        {
            MovingToTarget();
        }
    }
}
