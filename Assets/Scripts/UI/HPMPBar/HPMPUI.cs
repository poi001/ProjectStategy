using UnityEngine;
using UnityEngine.UI;

public class HPMPUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Slider _hpSlider;
    [SerializeField]
    private Slider _mpSlider;

    private Camera _mainCamera;
    private Character _target;
    private Vector3 _offset = new Vector3(0.0f, -0.15f, 0.0f);
    private bool _isInit = false;


    private void Update()
    {
        if (_isInit) 
        {
            // 월드 좌표 → 스크린 좌표
            Vector3 worldPos = _target.transform.position + _offset;
            Vector3 screenPos = _mainCamera.WorldToScreenPoint(worldPos);

            // UI에 적용
            _rectTransform.position = screenPos;
        }
    }

    public void Init(Character character)
    {
        _mainCamera = Camera.main;

        _target = character;
        _isInit = true;

        character.OnDamaged += ChangeHPBar;
        character.OnRegenMana += ChangeMPBar;
        character.OnUseMana += ChangeMPBar;

        _hpSlider.value = character.Stats.StatHandler.CurrentHP;
        _mpSlider.value = character.Stats.StatHandler.CurrentMP;
    }

    public void ChangeHPBar()
    {
        float curHP = _target.Stats.StatHandler.CurrentHP;
        float maxHP = _target.Stats.MaxHP;

        if (curHP <= 0.0f) _hpSlider.value = _hpSlider.minValue;
        else _hpSlider.value = curHP / maxHP;
    }

    public void ChangeMPBar()
    {
        float curMP = _target.Stats.StatHandler.CurrentMP;
        float maxMP = _target.Stats.MaxMP;

        if (curMP <= 0.0f) _mpSlider.value = _mpSlider.minValue;
        else _mpSlider.value = curMP / maxMP;
    }
}
