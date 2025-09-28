using UnityEngine;

public class RangedAttackAction : CharacterAttackAction
{
    public RangedAttackAction(Character character) : base(character)
    {
        _character = character;
    }

    public override void Attack()
    {
        base.Attack();

        _character.SpawnAttackObject(EAttackObject.Normal);
    }

    public void SpawnProjectile_NormalAttack()
    {
        // 나중에 오브젝트 풀링으로 실행 고려
        //Instantiate(_projectile, transform.position, )
    }

    //public void SpawnProjectile_NormalAttack()
    //{
    //    // 나중에 오브젝트 풀링으로 실행 고려
    //    Instantiate(_projectile, transform.position, )
    //}
}
