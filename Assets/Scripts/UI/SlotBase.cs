using UnityEngine;
using UnityEngine.UI;

public class SlotBase : MonoBehaviour
{
    [SerializeField] protected Image icon;


    public virtual void ChangeIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
