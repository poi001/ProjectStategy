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
        Debug.Log("ChangeGameImage");
    }

    public void ChangeTeamSettingImage()
    {
        Debug.Log("ChangeTeamSettingImage");
    }

    public void ChangeQuestImage()
    {
        Debug.Log("ChangeQuestImage");
    }

    public void ChangeStoreImage()
    {
        Debug.Log("ChangeStoreImage");
    }

    public void ChangeOptionImage()
    {
        Debug.Log("ChangeOptionImage");
    }
}
