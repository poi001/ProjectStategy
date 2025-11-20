using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
    IPointerExitHandler, IPointerMoveHandler
{
    //protected virtual void Interaction()
    //{
    //    // temp
    //    PlayerDataScriptableObject.Instance.Memebers = _playerCharacters_Temp.ToArray();
    //    PlayerDataScriptableObject.Instance.EnemyMemebers = _enemyCharacters_Temp.ToArray();

    //    LoadManager.Instance.ChangeGameState(EGameState.Battle);
    //}

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {

    }

    public virtual void OnPointerMove(PointerEventData eventData)
    {

    }
}
