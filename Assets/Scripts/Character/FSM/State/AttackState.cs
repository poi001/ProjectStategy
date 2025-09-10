
public class AttackState : CharacterBaseState
{
    public AttackState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentState = ECharacterState.Attack;
        StartAnimation_Trigger(stateMachine.Character.AnimationData.AttackParameterHash);
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
