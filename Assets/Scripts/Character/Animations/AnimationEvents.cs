using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character = GetComponentInParent<Character>();
    }

    public void TakeDamage()
    {

    }

    public void AttackEnd()
    {
        _character.StateMachine.ChanageState(_character.StateMachine.idleState);
    }
}
