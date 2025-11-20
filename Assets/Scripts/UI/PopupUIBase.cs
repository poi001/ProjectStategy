using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupUIBase : UIBase
{
    [SerializeField]
    private Button _exitBtn;


    public override IEnumerator Init()
    {
        yield return null;
    }

    public virtual void ExitPopup()
    {
        Destroy(gameObject);
    }

    public override void OnDisableFun()
    {

    }
}
