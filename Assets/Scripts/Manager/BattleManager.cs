using UnityEngine;

public class BattleManager : SingletonWithScene<BattleManager>
{
    [SerializeField]
    private GameObject[] _blueCharacters = new GameObject[DefineClass.NumberOfPlayers];
    [SerializeField]
    private GameObject[] _redCharacters = new GameObject[DefineClass.NumberOfPlayers];

    private GameObject[] _blueCharacters2 = new GameObject[DefineClass.NumberOfPlayers];
    private GameObject[] _redCharacters2 = new GameObject[DefineClass.NumberOfPlayers];

    private float _posX = -2.5f;
    private float _posY = 0.5f;
    private float[] _posXRate = { 0.0f, 0.0f, 2.5f, 0.0f, 0.0f };
    private float[] _posYRate = { 0.0f, -1.0f, 1.5f, -1.0f, -1.0f };

    private void Start()
    {
        SpawnBlueTeam();
        SpawnRedTeam();
    }

    private void SpawnBlueTeam()
    {
        for (int i = 0; i < _blueCharacters.Length; i++)
        {
            _posX -= _posXRate[i];
            _posY += _posYRate[i];
            Vector2 pos = new Vector2(_posX, _posY);
            _blueCharacters2[i] = Instantiate(_blueCharacters[i], pos, Quaternion.identity);
        }

        _posX = -2.5f;
        _posY = 0.5f;
}

    private void SpawnRedTeam()
    {
        _posX *= -1.0f;

        for (int i = 0; i < _redCharacters.Length; i++)
        {
            _posX += _posXRate[i];
            _posY += _posYRate[i];
            Vector2 pos = new Vector2(_posX, _posY);
            _redCharacters2[i] = Instantiate(_redCharacters[i], pos, Quaternion.identity);
        }

        _posX = -2.5f;
        _posY = 0.5f;
    }

    public Character GetNearEnemy(bool isBlueTeam, Vector2 pos)
    {
        return CopareNearestDistance(isBlueTeam, true, pos);
    }

    private Character GetNearAllyCharacter(bool isBlueTeam, Vector2 pos)
    {
        return CopareNearestDistance(isBlueTeam, false, pos);
    }

    private Character CopareNearestDistance(bool isBlueTeam, bool isFindObjectIsEnemy, Vector2 pos)
    {
        float distance;
        float nearestDistance = 9999.0f;
        Character nearestCharacter = null;
        GameObject[] characterObjects = new GameObject[DefineClass.NumberOfPlayers];

        if (isBlueTeam)
        {
            if (isFindObjectIsEnemy) characterObjects = _redCharacters2;
            else characterObjects = _blueCharacters2;
        }
        else
        {
            if (isFindObjectIsEnemy) characterObjects = _blueCharacters2;
            else characterObjects = _redCharacters2;
        }

        foreach (var obj in characterObjects)
        {
            distance = Vector2.Distance(pos, obj.transform.position);
            if (nearestDistance > distance)
            {
                nearestDistance = distance;
                obj.TryGetComponent<Character>(out nearestCharacter);
            }
        }

        return nearestCharacter;
    }

    //private void OnEnable()
    //{
    //    EventBus.Register(EGameState.Battle, SetTeam);
    //}

    //private void OnDisable()
    //{
    //    EventBus.Unregister(EGameState.Battle, SetTeam);
    //}


}
