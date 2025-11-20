

public class RangedAttackAction : CharacterAttackAction
{
    public RangedAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    public override void Attack()
    {
        base.Attack();

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
