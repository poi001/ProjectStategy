using UnityEngine;

public class SupportiveMovement : CharacterMovement
{
    public SupportiveMovement(Character character) : base(character)
    {
        ChaseCoefficient = 1.0f;
        SeparationCoefficient = 0.7f;
        WallAvoidCoefficient = 1.2f;
        RangeCoefficient = 0.95f;
    }
}
