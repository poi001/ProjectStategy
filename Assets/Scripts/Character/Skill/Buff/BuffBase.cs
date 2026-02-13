using UnityEngine;

public abstract class BuffBase : IBuff
{
    protected Character character;

    [Header("UI")]
    public Sprite Icon;

    [Header("Gameplay")]
    public bool IsPermanent;
    public float Duration;
    public bool IsStackable;
    public int MaxStack;

    public BuffBase(Character character)
    {
        this.character = character;
    }


    public abstract void Apply();
    public abstract void Remove();
    public void SetPermanent(bool isItPermanent) { IsPermanent = isItPermanent; }
    public void SetTimer(float time) { Duration = IsPermanent ? time : -1.0f; }
}
