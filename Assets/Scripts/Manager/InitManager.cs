using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : SingletonWithScene<InitManager>, IManagerInterface
{
    [SerializeField]
    [Header("파괴되지 않는 매니저 ( 순서를 확실히 정해서 기입할 것 )")]
    private List<GameObject> _initManagerObjects = new List<GameObject>();

    [SerializeField]
    [Header("Game Manager")]
    private GameObject _gameManagerObject;


    private void Start()
    {
        Instantiate(_gameManagerObject);
    }

    public IEnumerator Init()
    {
        foreach (var managerObj in _initManagerObjects)
        {
            if (Instantiate(managerObj).TryGetComponent<IManagerInterface>(out IManagerInterface initTarget))
            {
                yield return StartCoroutine(initTarget.Init());
            }
        }

        GameManager.Instance.OnManagersInitialized();
    }
}
