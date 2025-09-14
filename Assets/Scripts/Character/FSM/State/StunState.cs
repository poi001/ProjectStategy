using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : CharacterBaseState
{
    public StunState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentState = ECharacterState.Stun;
        StartAnimation_Bool(stateMachine.Character.AnimationData.StunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentState = ECharacterState.None;
        StopAnimation_Bool(stateMachine.Character.AnimationData.StunParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
