
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
}
