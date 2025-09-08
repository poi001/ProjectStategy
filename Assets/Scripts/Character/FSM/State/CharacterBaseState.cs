using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseState : IState
{
    protected CharacterStateMachine stateMachine;

    public CharacterBaseState(CharacterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }

    protected void StartAnimation_Bool(int animationHash)
    {
        //stateMachine.character.animator.SetBool(animationHash, true);
    }
    protected void StopAnimation_Bool(int animationHash)
    {
        //stateMachine.character.animator.SetBool(animationHash, false);
    }
    protected void StartAnimation_Trigger(int animationHash)
    {
        //stateMachine.character.animator.SetTrigger(animationHash);
    }
}
