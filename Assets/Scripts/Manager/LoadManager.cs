using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : SingletonWithMono<LoadManager>, IManagerInterface
{
    [Header("UI")]
    [SerializeField] private GameObject LoadingUICanvas;

    [Header("Setting")]
    [SerializeField] private float _fadeDuration = 1.5f;
    //[SerializeField] private float _fakeFillSpeed = 0.5f; // DOTween으로 로딩 바 애니메이션 속도 조절

    private Image _bgImage;


    public IEnumerator Init()
    {
        _bgImage = Instantiate(LoadingUICanvas, transform).GetComponentInChildren<Image>();
        _bgImage.DOFade(0.0f, 0.001f).OnComplete(() => _bgImage.enabled = false);
        yield return null;
    }

    public void ChangeGameState(EGameState gameState)
    {
        switch (gameState)
        {
            case EGameState.Bootstrap:
                GameManager.Instance.CurrentGameState = gameState;
                LoadScene(DefineClass.Scene_Bootstrap);
                break;
            case EGameState.Title:
                GameManager.Instance.CurrentGameState = gameState;
                LoadScene(DefineClass.Scene_Title);
                break;
            case EGameState.Lobby:
                GameManager.Instance.CurrentGameState = gameState;
                LoadScene(DefineClass.Scene_Lobby);
                break;
            case EGameState.Battle:
                GameManager.Instance.CurrentGameState = gameState;
                LoadScene(DefineClass.Scene_Battle);
                break;
            case EGameState.Room:
                break;
            case EGameState.Result:
                break;
            default:
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        //_bgImage.DOFade(1.0f, _fadeDuration);
        //yield return YieldCache.WaitForSeconds(_fadeDuration);

        //AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        //async.allowSceneActivation = false;

        //yield return new WaitUntil(() => async.isDone);
        //async.allowSceneActivation = true;
        //_bgImage.DOFade(0.0f, _fadeDuration);

        _bgImage.enabled = true;

        // 페이드 인
        _bgImage.DOFade(1.0f, _fadeDuration);
        yield return YieldCache.WaitForSeconds(_fadeDuration);

        // 비동기 씬 로드
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        // 로딩이 90% 이상 완료될 때까지 대기
        yield return new WaitUntil(() => async.progress >= 0.9f);

        // 씬 전환 (이걸 해야 다음 씬이 열림)
        async.allowSceneActivation = true;

        // 특정한 씬에만 존재하는 싱글톤의 초기화
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == sceneName);
        yield return YieldCache.WaitForSeconds(0.15f);

        var found = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IManagerWithSceneInterface>();

        foreach (var obj in found) yield return StartCoroutine(obj.Init());

        // 이벤트 버스
        EventBus.Publish(GameManager.Instance.CurrentGameState);

        // 여기서 로딩 완료 후 추가 연출 가능
        _bgImage.DOFade(0.0f, _fadeDuration).OnComplete((() => _bgImage.enabled = false));
        // yield return YieldCache.WaitForSeconds(1f); // 예: 로딩 완료 표시 등
    }

    //private IEnumerator WaitForSingletonWithScene()
    //{

    //}

    //Sequence seq = DOTween.Sequence();
    //seq.Append(loadingBar.DOValue(0.9f, 1f));
    //seq.AppendInterval(0.3f);
    //seq.Append(loadingBar.DOValue(1f, 0.3f));


    //public void LoadScene(string sceneName)
    //{
    //    StartCoroutine(LoadSceneRoutine(sceneName));
    //}

    //private IEnumerator LoadSceneRoutine(string sceneName)
    //{
    //    // 페이드 아웃 (0 → 1)
    //    fadeImage.DOFade(1f, fadeDuration);
    //    yield return new WaitForSeconds(fadeDuration);

    //    // 로딩 바 시작
    //    loadingBar.value = 0f;
    //    loadingBar.gameObject.SetActive(true);

    //    AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
    //    async.allowSceneActivation = false;

    //    float targetProgress = 0f;

    //    while (async.progress < 0.9f)
    //    {
    //        targetProgress = async.progress;
    //        loadingBar.DOValue(targetProgress, fakeFillSpeed);
    //        yield return new WaitForSeconds(fakeFillSpeed * 0.8f);
    //    }

    //    // 거의 다 로딩됨
    //    loadingBar.DOValue(1f, 0.3f);
    //    yield return new WaitForSeconds(0.4f);

    //    async.allowSceneActivation = true;
    //    yield return new WaitUntil(() => async.isDone);

    //    // 페이드 인 (1 → 0)
    //    fadeImage.DOFade(0f, fadeDuration);
    //    yield return new WaitForSeconds(fadeDuration);

    //    loadingBar.gameObject.SetActive(false);
    //}











    //private void FadeScreen(string _scene)
    //{
    //    _image.gameObject.SetActive(true);

    //    _image.DOFade(1, 0.5f).OnComplete(
    //        () =>
    //        {
    //            StartCoroutine("LoadScene", _scene);
    //        });
    //}

    //private IEnumerator LoadScene(string _scene)
    //{
    //    _percentText.gameObject.SetActive(true);
    //    _progressSlider.gameObject.SetActive(true);

    //    AsyncOperation async = SceneManager.LoadSceneAsync(_scene);
    //    async.allowSceneActivation = false;

    //    float _time = 0.0f;
    //    float _per = 0.0f;

    //    while (!(async.isDone))
    //    {
    //        yield return null;
    //        _time += Time.deltaTime;

    //        if (_per >= 90.0f)
    //        {
    //            _per = Mathf.Lerp(_per, 100.0f, _time);

    //            if (_per >= 100.0f)
    //            {
    //                async.allowSceneActivation = true;
    //            }
    //        }
    //        else
    //        {
    //            _per = Mathf.Lerp(_per, async.progress * 100f, _time);
    //            if (_per >= 90.0f) _time = 0.0f;
    //        }

    //        _progressSlider.value = _per * 0.01f;
    //        _percentText.text = _per.ToString("0") + "%"; //로딩 퍼센트 표기
    //    }
    //}
}
