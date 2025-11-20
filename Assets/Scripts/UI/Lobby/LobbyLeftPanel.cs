using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LobbyLeftPanel : MonoBehaviour
{
    [SerializeField] private Button _gameButton;
    [SerializeField] private Button _teamSettingButton;
    [SerializeField] private Button _questButton;
    [SerializeField] private Button _storeButton;
    [SerializeField] private Button _optionButton;

    private Button _currentSelected; // 현재 선택된 버튼
    private Color _selectedColor = Color.yellow;
    private Color _normalColor = Color.white;


    public void OnGameButton()
    {
        SelectedButton(_gameButton);

        if (UIManager.Instance.Dict_UI[DefineClass.UI_LobbyUICanvas].TryGetComponent<LobbyUICanvas>(out LobbyUICanvas ui))
            ui.OnPushGameButton?.Invoke();
    }
    public void OnTeamSettingButton()
    {
        SelectedButton(_teamSettingButton);

        if (UIManager.Instance.Dict_UI[DefineClass.UI_LobbyUICanvas].TryGetComponent<LobbyUICanvas>(out LobbyUICanvas ui))
            ui.OnPushTeamSettingButton?.Invoke();
    }
    public void OnQuestButton()
    {
        SelectedButton(_questButton);

        if (UIManager.Instance.Dict_UI[DefineClass.UI_LobbyUICanvas].TryGetComponent<LobbyUICanvas>(out LobbyUICanvas ui))
            ui.OnPushQuestButton?.Invoke();
    }
    public void OnStoreButton()
    {
        SelectedButton(_storeButton);

        if (UIManager.Instance.Dict_UI[DefineClass.UI_LobbyUICanvas].TryGetComponent<LobbyUICanvas>(out LobbyUICanvas ui))
            ui.OnPushStoreButton?.Invoke();
    }
    public void OnOptionButton()
    {
        SelectedButton(_optionButton);

        if (UIManager.Instance.Dict_UI[DefineClass.UI_LobbyUICanvas].TryGetComponent<LobbyUICanvas>(out LobbyUICanvas ui))
            ui.OnPushOptionButton?.Invoke();
    }

    private void SelectedButton(Button btn)
    {
        // 이전에 선택된 버튼이 있으면 색을 원래대로 돌림
        if (_currentSelected != null && _currentSelected != this)
            SetButtonColor(_currentSelected, _normalColor);

        // 자신을 선택된 버튼으로 지정하고 색 변경
        _currentSelected = btn;
        SetButtonColor(_currentSelected, _selectedColor);
    }
    private void SetButtonColor(Button btn, Color color)
    {
        if (btn.gameObject.TryGetComponent<Image>(out Image img))
            img.color = color;
    }
}
