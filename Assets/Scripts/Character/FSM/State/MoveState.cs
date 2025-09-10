
public class MoveState : CharacterBaseState
{
    public MoveState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentState = ECharacterState.Move;
        StartAnimation_Bool(stateMachine.Character.AnimationData.MoveParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.CurrentState = ECharacterState.None;
        StopAnimation_Bool(stateMachine.Character.AnimationData.MoveParameterHash);
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
