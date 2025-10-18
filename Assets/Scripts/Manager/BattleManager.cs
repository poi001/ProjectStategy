using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BattleManager : SingletonWithScene<BattleManager>, IManagerWithSceneInterface
{
    // 소환 위치 오브젝트
    [Header("SpawnObjectTransform")]
    [SerializeField]
    private Transform[] _playerSpawnPosArray;
    [SerializeField]
    private Transform[] _enemySpawnPosArray;

    // 캐릭터 오브젝트들
    private (GameObject, Character)[] _playerCharacters;
    private (GameObject, Character)[] _enemyCharacters;


    public IEnumerator Init()
    {
        SetupCharacters(out _playerCharacters, PlayerDataScriptableObject.Instance.Memebers, _playerSpawnPosArray);
        SetupCharacters(out _enemyCharacters, PlayerDataScriptableObject.Instance.EnemyMemebers, _enemySpawnPosArray);
        yield return StartCoroutine(InitCharacters());

        HPMPUICanvas hpmpUICanvas = UIManager.Instance.ShowUI(DefineClass.UI_HPMPBarUICanvas).GetComponent<HPMPUICanvas>();
        hpmpUICanvas.SpawnAllyHPMPBarUI(_playerCharacters);
        hpmpUICanvas.SpawnEnemyHPMPBarUI(_enemyCharacters);

        // 선택적으로 추가 처리
        // 예: AI 초기화, 카메라 위치 조정 등
        yield return new WaitForSeconds(0.2f); // 필요 시 연출용
    }

    private void SetupCharacters(out (GameObject, Character)[] characters, GameObject[] members, Transform[] transf)
    {
        characters = new(GameObject, Character)[DefineClass.NumberOfPlayers];

        for (int i = 0; i < DefineClass.NumberOfPlayers; i++)
        {
            if (!members[i])
            {
                characters[i].Item1 = null;
                characters[i].Item2 = null;
                continue;
            }

            characters[i].Item1 = Instantiate(members[i], transf[i].position, Quaternion.identity);
            characters[i].Item2 = characters[i].Item1.GetComponent<Character>();
        }
    }

    private IEnumerator InitCharacters()
    {
        foreach (var playerCharacters in _playerCharacters) playerCharacters.Item2.InitCharacter(true);
        foreach (var enemyCharacters in _enemyCharacters) enemyCharacters.Item2.InitCharacter(false);

        yield return null;
    }

    // 자신과 제일 가까운 캐릭터순으로 정렬됨
    public (GameObject, Character)[] GetAllyCharacters(Character character = null)
    {
        if (character != null)
        {
            Vector2 pos = (Vector2)character.transform.position;
            var sorted = _playerCharacters.OrderBy(c => Vector2.Distance(pos, c.Item2.transform.position)).ToArray();
            return sorted;
        }

        return _playerCharacters;
    }
    public (GameObject, Character)[] GetEnemyCharacters(Character character = null)
    {
        if (character != null)
        {
            Vector2 pos = (Vector2)character.transform.position;
            var sorted = _enemyCharacters.OrderBy(c => Vector2.Distance(pos, c.Item2.transform.position)).ToArray();
            return sorted;
        }

        return _enemyCharacters;
    }
}
