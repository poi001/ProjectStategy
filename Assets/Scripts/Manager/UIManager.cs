using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour// : SingletonWithMono<GameManager>
{
    public GameObject CharacterUICanvas;


    public void Init(List<Character> characters)
    {
        Instantiate(CharacterUICanvas, transform).GetComponent<HPMPUISpawner>().SpawnUI(characters);
    }
}
