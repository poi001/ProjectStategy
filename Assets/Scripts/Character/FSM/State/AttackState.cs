using UnityEngine;


public class AttackState : CharacterBaseState
{

    public AttackState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.CurrentCharacterState = ECharacterState.Attack;
        StartAnimation_Trigger(stateMachine.Character.AnimationData.AttackParameterHash);

        FlipCharacter();
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentCharacterState = ECharacterState.None;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }

    private void FlipCharacter()
    {
        // 플레이어가 적보다 오른쪽에 있을 때 반전
        if (stateMachine.Character.transform.position.x > stateMachine.Character.Target.transform.position.x &&
            !stateMachine.Character._isFacingLeft)
        {
            stateMachine.Character.Flip(); // 스케일을 반전
        }
        // 플레이어가 적보다 왼쪽에 있을 때 반전
        else if (stateMachine.Character.transform.position.x < stateMachine.Character.Target.transform.position.x &&
            stateMachine.Character._isFacingLeft)
        {
            stateMachine.Character.Flip(); // 스케일을 반전
        }
    }
}
