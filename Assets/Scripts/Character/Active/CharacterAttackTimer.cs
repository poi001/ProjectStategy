using UnityEngine;

public class CharacterAttackTimer
{
    private Character _character;
    private float _attackTimer = 0.0f;


    public CharacterAttackTimer(Character character)
    {
        _character = character;
    }

    public void UpdateAttackTimer()
    {
        if (_attackTimer >= 0.0f) _attackTimer -= Time.deltaTime;
    }

    public bool Attack()
    {
        if (_attackTimer <= 0.0f)
        {
            float attackSpeed = _character.Stats.AttackSpeed <= 0.01f ? 0.01f : _character.Stats.AttackSpeed;
            _attackTimer = 1.0f / attackSpeed;
            return true;
        }

        return false;
    }
}
