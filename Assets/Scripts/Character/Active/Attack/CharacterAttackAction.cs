using UnityEngine;

public abstract class CharacterAttackAction : IAttackAction
{
    protected Character _character;
    private float _attackTimer = 0.0f;


    public CharacterAttackAction(Character character)
    {
        _character = character;
        _character.OnUpdate += UpdateAttackTimer;
    }

    protected abstract void WhenAttackAction(Character target);

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

    public void Attack()
    {
        Character target = _character.Target;

        if (target != null)
        {
            if (!(target.CompareTag(DefineClass.Tag_DeadPlayer) || target.CompareTag(DefineClass.Tag_DeadEnemy)))
            {
                WhenAttackAction(target);
                _character.OnAttack?.Invoke();
            }
        }

    }

    public virtual void UseSkill()
    {

    }

    public virtual void UseUlt()
    {

    }
}
