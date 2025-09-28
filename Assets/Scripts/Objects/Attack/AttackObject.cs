using UnityEngine;


public abstract class AttackObject : MonoBehaviour
{
    protected SpriteRenderer sprite;
    public Character Owner { get; private set; }
    public float Damage { get; private set; }
    public float Speed;

    protected string enemyTag;
    protected string allyTag;


    private void Update()
    {
        UpdateObject();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public virtual void Init(Character owner, float speed = -1.0f)
    {
        Owner = owner;

        Damage = owner.Stats.AttackDamage;
        Speed = speed <= 1.0f ? Speed : speed;

        if (owner.IsPlayerTeam)
        {
            gameObject.layer = LayerMask.NameToLayer(DefineClass.Layer_PlayerSkill);
            gameObject.tag = DefineClass.Tag_PlayerSkill;
            enemyTag = DefineClass.Tag_Enemy;
            allyTag = DefineClass.Tag_Player;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer(DefineClass.Layer_EnemySkill);
            gameObject.tag = DefineClass.Tag_EnemySkill;
            enemyTag = DefineClass.Tag_Player;
            allyTag = DefineClass.Tag_Enemy;
        }

        sprite = GetComponent<SpriteRenderer>();
    }

    public abstract void UpdateObject();
}
