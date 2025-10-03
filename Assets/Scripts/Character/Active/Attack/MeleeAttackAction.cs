

public class MeleeAttackAction : CharacterAttackAction
{
    public MeleeAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    public override void Attack()
    {
        base.Attack();

        Character target = _character.Target;

        if (target != null)
        {
            if (!(target.CompareTag(DefineClass.Tag_DeadPlayer) || target.CompareTag(DefineClass.Tag_DeadEnemy)))
            {
                _character.Target.Stats.StatHandler.TakeDamage(_character.Stats.AttackDamage);
            }
        }
    }
}
