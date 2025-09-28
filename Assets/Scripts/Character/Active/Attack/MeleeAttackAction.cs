using UnityEngine;

public class MeleeAttackAction : CharacterAttackAction
{
    public MeleeAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    public override void Attack()
    {
        base.Attack();

        _character.Target.Stats.StatHandler.TakeDamaged(_character.Stats.AttackDamage);
    }
}
