//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class OnOffButton : ButtonBase
//{
//    [SerializeField]
//    protected Image btnImage;
//    [SerializeField]
//    protected Sprite upBtn;
//    [SerializeField]
//    protected Sprite downBtn;

//    protected bool isPressed = false;


//    private void OnPress()
//    {
//        btnImage.sprite = downBtn;
//        isPressed = true;
//    }

//    private void OffPress()
//    {
//        btnImage.sprite = upBtn;
//        isPressed = false;
//    }

//    protected virtual void Interaction()
//    {
//        // temp
//        PlayerDataScriptableObject.Instance.Memebers = _playerCharacters_Temp.ToArray();
//        PlayerDataScriptableObject.Instance.EnemyMemebers = _enemyCharacters_Temp.ToArray();

//        LoadManager.Instance.ChangeGameState(EGameState.Battle);
//    }

//    public virtual void OnPointerClick(PointerEventData eventData)
//    {
//        Interaction();
//    }

//    public virtual void OnPointerUp(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Left)
//        {
//            OffPress();
//        }
//    }

//    public virtual void OnPointerDown(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Left)
//        {
//            OnPress();
//        }
//    }

//    public virtual void OnPointerEnter(PointerEventData eventData)
//    {

//    }

//    public virtual void OnPointerExit(PointerEventData eventData)
//    {
//        if (isPressed)
//        {
//            OffPress();
//        }
//    }

//    public virtual void OnPointerMove(PointerEventData eventData)
//    {

//    }
//}
