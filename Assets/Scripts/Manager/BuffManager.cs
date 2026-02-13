using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : IManagerInterface
{
    private List<BuffBase>[] _allyCharacterBuff = new List<BuffBase>[DefineClass.NumberOfPlayers];
    private List<BuffBase>[] _enemyCharacterBuff = new List<BuffBase>[DefineClass.NumberOfPlayers];


    public IEnumerator Init()
    {
        for (int i = 0; i < DefineClass.NumberOfPlayers; i++)
        {
            _allyCharacterBuff[i] = new List<BuffBase>();
            _enemyCharacterBuff[i] = new List<BuffBase>();
        }

        yield return null;
    }

    public void AddBuff(BuffBase buff, bool isEnemy, int num)
    {
        if (num >= DefineClass.NumberOfPlayers) return;

        if (isEnemy)
        {
            _enemyCharacterBuff[num].Add(buff);
        }
        else
        {
            _allyCharacterBuff[num].Add(buff);
        }
    }

    public List<BuffBase> GetBuffList(bool isEnemy, int num)
    {
        if (num >= DefineClass.NumberOfPlayers) return null;

        return isEnemy ? _enemyCharacterBuff[num] : _allyCharacterBuff[num];
    }


}
