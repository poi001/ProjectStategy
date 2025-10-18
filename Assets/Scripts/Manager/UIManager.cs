using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonWithMono<UIManager>, IManagerInterface
{
    //UI 인터페이스로 바꾸기
    public Dictionary<string, GameObject> Dict_UI { get; private set; } = new Dictionary<string, GameObject>();


    public IEnumerator Init()
    {
        // 리소스 폴더에서 Canvas들을 받아온다
        Object[] uiCanvasObjects = Resources.LoadAll(DefineClass.Path_UICanvas, typeof(GameObject));
        List<string> uiCanvasPrefabNames = new List<string>();

        // Canvas Prefab들의 이름을 List에 담아 놓는다.
        foreach (var obj in uiCanvasObjects)
        {
            uiCanvasPrefabNames.Add(obj.name);
        }

        // 이름을 담아 놓은 리스트의 원소들을 하나씩 꺼내 로드한다
        foreach (string name in uiCanvasPrefabNames)
        {
            string path = $"{DefineClass.Path_UICanvas}/{name}";
            ResourceRequest request = Resources.LoadAsync<GameObject>(path);
            yield return request;

            if (request.asset != null)
            {
                // null이 아니라면 딕셔너리에 넣는다
                GameObject prefab = request.asset as GameObject;
                Dict_UI.Add(name, Instantiate(prefab, transform));
                Dict_UI[name].SetActive(false);
            }
            else
            {
                Debug.LogWarning($"? Failed to load: {name}");
            }
        }

        Debug.Log($"?? 총 {Dict_UI.Count}개의 프리팹을 비동기로 로드 완료!");

        yield return null;
    }

    public GameObject ShowUI(string key)
    {
        if (!Dict_UI.ContainsKey(key))
        {
            Debug.LogWarning($"? Failed to load: {key}");
            return null;
        }

        Dict_UI[key].SetActive(true);
        return Dict_UI[key];
    }

    public GameObject HideUI(string key)
    {
        if (!Dict_UI.ContainsKey(key))
        {
            Debug.LogWarning($"? Failed to load: {key}");
            return null;
        }

        Dict_UI[key].SetActive(false);
        return Dict_UI[key];
    }

    public void ToggleUI(string key)
    {
        if (!Dict_UI.ContainsKey(key))
        {
            Debug.LogWarning($"? Failed to load: {key}");
            return;
        }

        if (Dict_UI[key].activeSelf) HideUI(key);
        else ShowUI(key);
    }
}
