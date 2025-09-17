
public class DeathState : CharacterBaseState
{
    public DeathState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentCharacterState = ECharacterState.Death;
        StartAnimation_Trigger(stateMachine.Character.AnimationData.DeathParameterHash);
        StartAnimation_Bool(stateMachine.Character.AnimationData.IsDeathParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentCharacterState = ECharacterState.None;
        StopAnimation_Bool(stateMachine.Character.AnimationData.IsDeathParameterHash);
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
