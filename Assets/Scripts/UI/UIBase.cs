using System.Collections;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public string UIName { get; protected set; }


    public virtual IEnumerator Init()
    {
        yield return null;
    }
}
