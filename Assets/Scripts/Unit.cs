using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    public string unitName;
	public int unitLevel;
	public float damage;
	public float defense;
	public float maxHP;
	public float currentHP;
	public int Item_Number_1;
	public int Item_Number_2;
   
    private void Start()
	{
		currentHP = maxHP;
	}


    public void Update()
    {
        if (currentHP <= 0)
        {
            Debug.Log("Death working");
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
        }
    }


}
