
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
    Unit PlayerUnit;
    Unit ZombieCoreUnit;

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
















        if (PlayerUnit.currentHP >= 0 )  //Once we have an enemy attack coded in move this script to there, to check  if the player is dead
        {
            GameOverUI.SetActive(true);
        }
    } 

}
