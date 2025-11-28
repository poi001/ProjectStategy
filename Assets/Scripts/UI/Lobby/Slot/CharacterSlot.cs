using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : SlotBase
{
    [SerializeField] private GameObject _selectAnimation;
    public GameObject SelectAnimation => _selectAnimation;
    private BottomPanel_TeamSetting _teamSetting;

    private void Awake()
    {
        _teamSetting = GetComponentInParent<BottomPanel_TeamSetting>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        _teamSetting?.SelectSlot(this);
    }
}
