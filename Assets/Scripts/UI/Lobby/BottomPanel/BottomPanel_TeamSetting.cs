using System;
using UnityEngine;

public class BottomPanel_TeamSetting : MonoBehaviour
{
    // CharacterSlotsGroup
    //[SerializeField] private CharacterSlot _slot1;
    //[SerializeField] private CharacterSlot _slot2;
    //[SerializeField] private CharacterSlot _slot3;
    //[SerializeField] private CharacterSlot _slot4;
    //[SerializeField] private CharacterSlot _slot5;

    // SelectedCharacterSlotsGroup
    //[SerializeField] private CharacterSlot _selectedSlot1;
    //[SerializeField] private CharacterSlot _selectedSlot2;
    //[SerializeField] private CharacterSlot _selectedSlot3;
    //[SerializeField] private CharacterSlot _selectedSlot4;
    //[SerializeField] private CharacterSlot _selectedSlot5;

    // Description


    // 선택된 버튼
    private CharacterSlot _selectedSlot;



    public void SelectSlot(CharacterSlot slot)
    {
        if (_selectedSlot == null) WhenSelectedSlotIsNull(slot);
        else WhenSelectedSlotIsExist(slot);
    }

    private void WhenSelectedSlotIsNull(CharacterSlot slot)
    {
        _selectedSlot = slot;
        slot.SelectAnimation.SetActive(true);
        //설명창 보여주기
    }

    private void WhenSelectedSlotIsExist(CharacterSlot slot)
    {
        _selectedSlot.SelectAnimation.SetActive(false);
        if (_selectedSlot != slot) ChangeSlotEachother();
        _selectedSlot = null;
    }

    private void ChangeSlotEachother()
    {

    }
}
