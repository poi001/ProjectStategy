using UnityEngine;

public class AggressiveMovement : CharacterMovement
{
    public AggressiveMovement(Character character) : base(character)
    {
        ChaseCoefficient = 1.2f;
        SeparationCoefficient = 0.3f;
        WallAvoidCoefficient = 0.8f;
        RangeCoefficient = 0.35f;
    }

    protected override Vector3 GetFinalMoveDir()
    {
        Vector3 characterPos = character.transform.position;
        Vector3 targetPos = character.Target.transform.position;

        Vector3 dirFromTarget = (characterPos - targetPos).normalized;
        Vector3 maxRangePos = targetPos + dirFromTarget * character.Stats.Range * RangeCoefficient;

        Vector3 rangeDir = (maxRangePos - characterPos).normalized;
        Vector3 separation = CalculateSeparation();
        Vector3 wallAvoid = CalculateWallAvoidance();

        // 가중치 계산
        Vector3 finalDir =
            rangeDir * ChaseCoefficient +
            separation * SeparationCoefficient +
            wallAvoid * WallAvoidCoefficient;

        return finalDir.normalized;
    }
}
