using UnityEngine;


public class Projectile : AttackObject
{
    private Vector3 _targetPosNormalized;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag(enemyTag))
        {
            collision.GetComponent<Character>().Stats.StatHandler.TakeDamaged(Damage);
            Destroy(gameObject);
        }
    }

    public override void Init(Character owner, float speed = -1)
    {
        base.Init(owner, speed);

        _targetPosNormalized = (Owner.Target.transform.position - Owner.transform.position).normalized;

        if (_targetPosNormalized.x < 0.0f) sprite.flipX = true;
    }

    public override void UpdateObject()
    {
        transform.position += _targetPosNormalized * Time.deltaTime * Speed;
    }
}
