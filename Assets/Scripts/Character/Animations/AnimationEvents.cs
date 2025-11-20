using UnityEngine;
using UnityEngine.TextCore.Text;

public class AnimationEvents : MonoBehaviour
{
    private Character _character;


    private void Start()
    {
        _character = GetComponentInParent<Character>();
    }

    public void Attack()
    {
        _character.AttackAction.Attack();
    }

    public void AttackEnd()
    {
        _character.StateMachine.ChanageState(_character.StateMachine.idleState);
    }
}
