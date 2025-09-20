
public class MeleeMovement : CharacterMovement
{
    public MeleeMovement (Character character) : base(character)
    {

    }

    protected override void Movement()
    {
        MovingToTarget();
    }
}
