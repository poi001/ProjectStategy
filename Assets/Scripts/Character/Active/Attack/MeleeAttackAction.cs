

public class MeleeAttackAction : CharacterAttackAction
{
    public MeleeAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    protected override void WhenAttackAction(Character target)
    {
        target.Stats.StatHandler.TakeDamage(_character.Stats.AttackDamage, _character.Stats);
    }
}
