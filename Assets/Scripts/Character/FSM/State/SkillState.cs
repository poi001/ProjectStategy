using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : CharacterBaseState
{
    public SkillState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentState = ECharacterState.Skill;
        StartAnimation_Trigger(stateMachine.Character.AnimationData.SkillParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentState = ECharacterState.None;
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
