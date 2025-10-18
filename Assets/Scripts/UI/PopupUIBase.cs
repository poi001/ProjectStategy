using UnityEngine;
using UnityEngine.UI;

public class PopupUIBase : UIBase
{
    [SerializeField]
    private Button _exitBtn;


    public virtual void ExitPopup()
    {
        Destroy(gameObject);
    }
}
