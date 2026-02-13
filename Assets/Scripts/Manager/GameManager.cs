using System.Collections;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    public EGameState CurrentGameState = EGameState.None;

    // 카메라 설정
    public Camera Cam { get; private set; }
    public float CamMinX { get; private set; }
    public float CamMaxX { get; private set; }
    public float CamMinY { get; private set; }
    public float CamMaxY { get; private set; }


    private void Start()
    {
        StartCoroutine(InitManager.Instance.Init());
    }

    public void OnManagersInitialized()
    {
        LoadManager.Instance.ChangeGameState(EGameState.Lobby);
    }

    public void UpdateCameraBounds()
    {
        Cam = Camera.main;
        float height = Cam.orthographicSize;
        float width = height * Cam.aspect;

        CamMinX = -width;
        CamMaxX = width;
        CamMinY = -height;
        CamMaxY = height;
    }
}
