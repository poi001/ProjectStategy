using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public abstract IEnumerator Init();
    public abstract void OnDisableFun();


    private void OnEnable()
    {
        OnDisableFun();
    }
}
