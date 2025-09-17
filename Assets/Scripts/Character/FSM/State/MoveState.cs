
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
    }
}
