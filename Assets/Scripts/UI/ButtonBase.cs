using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
    IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField]
    protected Image btnImage;
    [SerializeField]
    protected Sprite upBtn;
    [SerializeField]
    protected Sprite downBtn;

    protected bool isPressed = false;

    // 인스펙터에 넣은 프리팹 ( 임의 )
    [Header("Temp")]
    [SerializeField]
    private List<GameObject> _playerCharacters_Temp;
    [SerializeField]
    private List<GameObject> _enemyCharacters_Temp;


    private void OnPress()
    {
        btnImage.sprite = downBtn;
        isPressed = true;
    }

    private void OffPress()
    {
        btnImage.sprite = upBtn;
        isPressed = false;
    }

    protected virtual void Interaction()
    {
        // temp
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0) PlayerDataScriptableObject.Instance.Memebers[j] = _playerCharacters_Temp[j];
                else PlayerDataScriptableObject.Instance.EnemyMemebers[j] = _enemyCharacters_Temp[j];
            }
        }

        LoadManager.Instance.ChangeGameState(EGameState.Battle);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Interaction();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OffPress();
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnPress();
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (isPressed)
        {
            OffPress();
        }
    }

    public virtual void OnPointerMove(PointerEventData eventData)
    {

    }
}
