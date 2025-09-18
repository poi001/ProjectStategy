

public class IdleState : CharacterBaseState
{


    public IdleState(CharacterStateMachine characterStateMachine) : base(characterStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.CurrentCharacterState = ECharacterState.Idle;
        StopAnimation_Bool(stateMachine.Character.AnimationData.MoveParameterHash);
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

        // 제일 가까운 적을 찾음
        GetCharacter();
    }

    private void GetCharacter()
    {
        if (BattleManager.Instance != null)
        {
            if (BattleManager.Instance.GetActiveEnemy(stateMachine.Character.IsPlayerTeam))
            {
                stateMachine.ChanageState(stateMachine.moveState);
            }
        }
    }
}
