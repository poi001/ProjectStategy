using UnityEngine;

public class CharacterAttackAction
{
    protected Character _character;
    private float _regenManaValue = 5.0f;

    public CharacterAttackAction(Character character)
    {
        _character = character;
    }

    public virtual void Attack()
    {
        _character.Stats.StatHandler.RegenMana(_regenManaValue);
    }
}
