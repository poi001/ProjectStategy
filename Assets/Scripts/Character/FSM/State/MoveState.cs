using System.Collections;
using UnityEngine;

public class MoveState : CharacterBaseState
{
    private Vector2 _targetPos = new Vector2(1000.0f, 0.0f);
    private bool _isFacingLeft = true;

    public MoveState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentCharacterState = ECharacterState.Move;
        StartAnimation_Bool(stateMachine.Character.AnimationData.MoveParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentCharacterState = ECharacterState.None;
        StopAnimation_Bool(stateMachine.Character.AnimationData.MoveParameterHash);
        CoroutineManager.Instance.StopManagedCoroutine(DefineClass.FindToTargetCoroutineKey);

        _targetPos = new Vector2(1000.0f, 0.0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();

        // 제일 가까운 적을 찾음
        CoroutineManager.Instance.StartManagedCoroutine(FindToTarget_Coroutine(0.15f), DefineClass.FindToTargetCoroutineKey);

        // 적을 못 찾았으면 Idle상태로 변경
        if (_targetPos.x >= 999.0f)
        {
            stateMachine.ChanageState(stateMachine.idleState);
            return;
        }

        // 공격 사거리까지 닿았는지 확인
        if (stateMachine.Character.Stats.Range >= Vector2.Distance(stateMachine.Character.transform.position, _targetPos))
        {
            stateMachine.ChanageState(stateMachine.attackState);
            return;
        }

        // 적 위치에 따라, 캐릭터의 좌우 방향을 정해줌
        FlipCharacter();

        // 그 적에게 이동함
        stateMachine.Character.transform.position =
            Vector2.MoveTowards(
                stateMachine.Character.
                transform.position,
                _targetPos,
                Time.deltaTime * stateMachine.Character.Stats.MoveSpeed
                );
    }

    private IEnumerator FindToTarget_Coroutine(float interval)
    {
        while (true)
        {
            if (BattleManager.Instance != null)
            {
                Character character = BattleManager.Instance.GetNearEnemy
                    (stateMachine.Character.IsPlayerTeam, stateMachine.Character.transform.position);

                // 적이 존재하면 적의 포지션을, 없으면 임의의 포지션을 넣어 구분한다.
                if (character != null) _targetPos = character.transform.position;
            }

            yield return YieldCache.WaitForSeconds(interval);
        }
    }

    private void FlipCharacter()
    {
        // 플레이어가 적보다 오른쪽에 있을 때 반전
        if (stateMachine.Character.transform.position.x > _targetPos.x && !_isFacingLeft)
        {
            _isFacingLeft = true; // 오른쪽을 보고 있었으면 반전
            Flip(); // 스케일을 반전
        }
        // 플레이어가 적보다 왼쪽에 있을 때 반전
        else if (stateMachine.Character.transform.position.x < _targetPos.x && _isFacingLeft)
        {
            _isFacingLeft = false; // 왼쪽을 보고 있었으면 반전
            Flip(); // 스케일을 반전
        }
    }

    private void Flip()
    {
        Vector3 localScale = stateMachine.Character.transform.localScale; // 현재 스케일의 x 값 반전
        localScale.x *= -1.0f; // 좌우 반전
        stateMachine.Character.transform.localScale = localScale;
    }
}
