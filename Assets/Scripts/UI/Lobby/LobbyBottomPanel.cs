using UnityEngine;

public class LobbyBottomPanel : MonoBehaviour
{
    //public ButtonColorController currentSelected; // 현재 선택된 버튼
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _teamSettingPanel;
    [SerializeField] private GameObject _questPanel;
    [SerializeField] private GameObject _storePanel;
    [SerializeField] private GameObject _optionPanel;


    public void ChangeGameImage()
    {
        _gamePanel.SetActive(true);
        _teamSettingPanel.SetActive(false);
        _questPanel.SetActive(false);
        _storePanel.SetActive(false);
        _optionPanel.SetActive(false);

        Debug.Log("ChangeGameImage");
    }

    public void ChangeTeamSettingImage()
    {
        _gamePanel.SetActive(false);
        _teamSettingPanel.SetActive(true);
        _questPanel.SetActive(false);
        _storePanel.SetActive(false);
        _optionPanel.SetActive(false);

        Debug.Log("ChangeTeamSettingImage");
    }

    public void ChangeQuestImage()
    {
        _gamePanel.SetActive(false);
        _teamSettingPanel.SetActive(false);
        _questPanel.SetActive(true);
        _storePanel.SetActive(false);
        _optionPanel.SetActive(false);

        Debug.Log("ChangeQuestImage");
    }

    public void ChangeStoreImage()
    {
        _gamePanel.SetActive(false);
        _teamSettingPanel.SetActive(false);
        _questPanel.SetActive(false);
        _storePanel.SetActive(true);
        _optionPanel.SetActive(false);

        Debug.Log("ChangeStoreImage");
    }

    public void ChangeOptionImage()
    {
        _gamePanel.SetActive(false);
        _teamSettingPanel.SetActive(false);
        _questPanel.SetActive(false);
        _storePanel.SetActive(false);
        _optionPanel.SetActive(true);

        Debug.Log("ChangeOptionImage");
    }
}
