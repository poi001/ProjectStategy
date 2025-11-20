using UnityEngine;

public class AggressiveMovement : CharacterMovement
{
    public AggressiveMovement(Character character) : base(character)
    {

    }

    protected override void Movement()
    {
        MovingToTarget();
    }
}
