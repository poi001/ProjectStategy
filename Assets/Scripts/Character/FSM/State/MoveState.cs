using UnityEngine;

public class MoveState : CharacterBaseState
{
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Character.Target != null)
        {
            if (stateMachine.Character.Stats.Range >=
                    Vector2.Distance(stateMachine.Character.transform.position, stateMachine.Character.Target.transform.position))
            {
                if (stateMachine.Character.AttackTimer.Attack())
                {
                    stateMachine.ChanageState(stateMachine.attackState);
                    return;
                }
            }
        }

        stateMachine.Character.Movement.UpdateMovement();
    }
}
