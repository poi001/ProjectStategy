using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPMPUICanvas : UIBase
{
    [SerializeField]
    private GameObject AllyHPMPBarObject;
    [SerializeField]
    private GameObject EnemyHPMPBarObject;

    public override IEnumerator Init()
    {
        EventBus.Register(EGameState.Battle, EventBusRegistDelegate_ShowUI);

        yield return new WaitUntil(() => EventBus.Events[EGameState.Battle] != null);
    }

    public override void OnDisableFun()
    {

    }

    private void EventBusRegistDelegate_ShowUI()
    {
        UIManager.Instance.ShowUI(DefineClass.UI_HPMPBarUICanvas);
    }

    public void SpawnAllyHPMPBarUI((GameObject, Character)[] characters)
    {
        foreach (var character in characters) 
        {
            if (character.Item2 != null)
            {
                Instantiate(AllyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character.Item2);
            }
        }
    }

    public void SpawnEnemyHPMPBarUI((GameObject, Character)[] characters)
    {
        foreach ((GameObject, Character) character in characters)
        {
            Instantiate(EnemyHPMPBarObject, transform).GetComponent<HPMPUI>().Init(character.Item2);
        }
    }
}
