using UnityEngine;

public class DefensiveMovement : CharacterMovement
{
    public DefensiveMovement(Character character) : base(character)
    {
        ChaseCoefficient = 1.0f;
        SeparationCoefficient = 0.7f;
        WallAvoidCoefficient = 1.2f;
        RangeCoefficient = 0.95f;
    }
}
