

public class RangedAttackAction : CharacterAttackAction
{
    public RangedAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    protected override void WhenAttackAction(Character target)
    {
        _character.SpawnAttackObject();
    }

    public override void UseSkill()
    {
        base.UseSkill();


    }

    public override void UseUlt()
    {
        base.UseUlt();


    }
}
