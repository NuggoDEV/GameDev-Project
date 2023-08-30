
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Unit PlayerUnit;
    public Unit ZombieCoreUnit;

    public BattleState state;

    public GameObject GameOverUI;

    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle() //this can be used to start spawning zombie and get the game ready etc
    {
        yield return new WaitForSeconds(2f);
















        
    } 

}
