using UnityEngine;

public abstract class CharacterMovement
{
    // 캐릭터
    protected Character character;

    // 카메라
    protected Camera cam;
    protected float minX;
    protected float maxX;
    protected float minY;
    protected float maxY;

    // 가중치 ( 각각 가중치가 높을 시 순서대로 '고집 셈', '개인 공간 중시', '겁 많음'  )
        // 고집 ( 너무 낮으면: 목적이 흐려짐, 캐릭터가 우왕좌왕 ), ( 너무 높으면: 로봇처럼 직선 이동, 다른 보정을 무시 )
    public float ChaseCoefficient = 1.0f;     // 지금 이 캐릭터가 가장 하고 싶은 행동
        // 개인 공간 중시 ( 너무 낮으면: 캐릭터 겹침, 공격 판정, 이펙트 문제 ), ( 너무 높으면: 전투 중 진형 붕괴, 옆으로만 움직임 )
    public float SeparationCoefficient = 1.0f;   // 아군과 얼마나 거리를 유지할 것인가
        // 겁 ( 너무 낮으면: 구석에 몰려 떨림 ), ( 너무 높으면: 중앙으로만 모임, 가장자리 전투가 안 일어남 )
    public float WallAvoidCoefficient = 1.0f;    // 벽이 얼마나 위험한가
        // 사거리 ( 너무 낮으면: 상대방 코 앞까지 추격 ), ( 너무 높으면: 상대방과 긴 거리를 유지 )
    public float RangeCoefficient = 1.0f;       // 상대를 따라가는 가중치


    public CharacterMovement(Character character)
    {
        this.character = character;
    }

    public void UpdateMovement()
    {
        // 카메라 해상도를 Update
        UpdateBounds();

        // 움직임
        Movement();

        // 적 위치에 따라, 캐릭터의 좌우 방향을 정해줌
        FlipCharacter();
    }

    private void UpdateBounds()
    {
        cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        minX = -width;
        maxX = width;
        minY = -height;
        maxY = height;
    }

    private void Movement()
    {
        character.Direction = GetFinalMoveDir();
        character.transform.position += (Vector3)character.Direction * Time.deltaTime * character.Stats.MoveSpeed;
        ClampPosition();
    }

    private void FlipCharacter()
    {
        // 플레이어가 오른쪽을 향할 때
        if (character.Direction.x > 0.0f && character.IsFacingLeft)
        {
            character.Flip(); // 스케일을 반전
        }
        // 플레이어가 왼쪽을 향할 때
        else if (character.Direction.x < 0.0f && !character.IsFacingLeft)
        {
            character.Flip(); // 스케일을 반전
        }
    }

    protected void ClampPosition()
    {
        Vector3 pos = character.transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        character.transform.position = pos;
    }

    protected virtual Vector3 GetFinalMoveDir()
    {
        Vector3 characterPos = character.transform.position;
        Vector3 targetPos = character.Target.transform.position;

        Vector3 dirFromTarget = (characterPos - targetPos).normalized;
        Vector3 maxRangePos = targetPos + dirFromTarget * character.Stats.Range * 0.95f;

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

    // 벽
    protected Vector3 CalculateWallAvoidance()
    {
        Vector3 avoidance = Vector3.zero;
        Vector3 pos = character.transform.position;

        float dangerDist = 1.5f;

        // 벽 근처로 다가갈 시, 가중치를 더한다. ( 반대방향으로 가중한다 )
        if (pos.x < minX + dangerDist)
            avoidance += Vector3.right * (dangerDist - (pos.x - minX));

        if (pos.x > maxX - dangerDist)
            avoidance += Vector3.left * (dangerDist - (maxX - pos.x));

        if (pos.y < minY + dangerDist)
            avoidance += Vector3.up * (dangerDist - (pos.y - minY));

        if (pos.y > maxY - dangerDist)
            avoidance += Vector3.down * (dangerDist - (maxY - pos.y));

        return avoidance;
    }

    //    최종 이동 방향 =
    //사거리 유지 +
    //아군 분리 +
    //벽 회피

    protected Vector3 CalculateSeparation()
    {
        //Vector3 characterPos = character.transform.position;
        Vector3 separation = Vector3.zero;
        int count = 0;

        Collider2D[] allies = Physics2D.OverlapCircleAll(
            character.transform.position,
            1.2f,   // 분리 반경
            character.gameObject.layer
        );

        foreach (var ally in allies)
        {
            // 주변에 탐색한 캐릭터가 자기자신이면 continue
            if (ally.transform == character.transform) continue;

            // 탐색된 캐릭터와 자신의 벡터 차이를 구하고 거리를 구한다.
            Vector3 diff = character.transform.position - ally.transform.position;
            float dist = diff.magnitude;

            // 거리가 있다면
            if (dist > 0.0f)
            {
                // 가까운 아군일수록 더 강하게 밀어내고, 멀리 있는 아군은 거의 무시하기 위해서
                // ex)
                // 거리가 0.3일시 => 1 / 0.3 ≈ 3.33  매우 강하게 밀림
                // 거리가 5.0일시 => 1 / 5 = 0.2     거의 없음
                separation += diff.normalized / dist;
                count++;
            }
        }

        // 탐색된 캐릭터가 많다면, 그 수만큼 퍼져나가는 벡터의 크기를 줄인다.
        if (count > 0)
            separation /= count;

        return separation;
    }

    //Vector3 GetDefensiveMoveDir()
    //{
    //    Vector3 baseDir = (desiredMaxRangePos - transform.position).normalized;
    //    Vector3 separation = CalculateSeparation();

    //    Vector3 finalDir = baseDir + separation * 0.7f;
    //    return finalDir.normalized;
    //}

//    Separation 반경	1.0 ~ 1.5
//Separation 강도	0.5 ~ 1.0
}
