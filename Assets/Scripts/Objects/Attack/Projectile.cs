using UnityEngine;


public class Projectile : AttackObject
{
    [SerializeField] private float _speed;
    private Vector3 _targetPosNormalized;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag(enemyTag))
        {
            collision.GetComponent<Character>().Stats.StatHandler.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public override void Init(Character owner)
    {
        base.Init(owner);

        if (Owner == null) Debug.Log("Owner");
        else if (Owner.Target == null) Debug.Log("Target");
        _targetPosNormalized = (Owner.Target.transform.position - Owner.transform.position).normalized;
        SettingRotation(_targetPosNormalized);
    }

    public override void UpdateObject()
    {
        transform.position += _targetPosNormalized * Time.deltaTime * _speed;
    }

    private void SettingRotation(Vector3 pos)
    {
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
