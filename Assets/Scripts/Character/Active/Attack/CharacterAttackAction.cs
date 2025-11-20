using UnityEngine;

public class CharacterAttackAction : IAttackAction
{
    protected Character _character;
    private float _attackTimer = 0.0f;
    private float _regenManaValue = 5.0f;


    public CharacterAttackAction(Character character)
    {
        _character = character;
        CreateAttackAction(character.CharacterType);
        _character.OnUpdate += UpdateAttackTimer;
    }

    private void CreateAttackAction(ECharacterType type)
    {
        switch (type)
        {
            case ECharacterType.Melee:
                break;
            case ECharacterType.Ranged:
                break;
            case ECharacterType.Magician:
                break;
            case ECharacterType.Healer:
                break;
            default:
                break;
        }
    }

    public void UpdateAttackTimer()
    {
        if (_attackTimer > 0.0f) _attackTimer -= Time.deltaTime;
    }

    public bool IsPossibleAttack()
    {
        if (_attackTimer <= 0.0f)
        {
            float attackSpeed = _character.Stats.AttackSpeed <= 0.01f ? 0.01f : _character.Stats.AttackSpeed;
            _attackTimer = 1.0f / attackSpeed;
            return true;
        }

        return false;
    }

    public virtual void Attack()
    {
        _character.Stats.StatHandler.RegenMana(_regenManaValue);
    }

    public virtual void UseSkill()
    {

    }

    public virtual void UseUlt()
    {

    }
}
