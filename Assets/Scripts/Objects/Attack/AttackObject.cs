using UnityEngine;


public abstract class AttackObject : MonoBehaviour, IAttackObject
{
    protected SpriteRenderer sprite;
    public Character Owner { get; private set; }
    public float Damage { get; private set; }

    protected string enemyTag;
    protected string allyTag;


    private void Update()
    {
        UpdateObject();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public virtual void Init(Character owner)
    {
        Owner = owner;
        Damage = owner.Stats.AttackDamage;

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
