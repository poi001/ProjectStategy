using UnityEngine;
using UnityEngine.UI;

public class SlotBase : ButtonBase
{
    [SerializeField] protected Image icon;


    public virtual void ChangeIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
