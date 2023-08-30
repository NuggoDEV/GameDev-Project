using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;
	public float damage;
	public float defense;
	public float maxHP;
	public float currentHP;


	private void Start()
	{
		currentHP = maxHP;
	}

    public bool TakeDamage(float dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}


}
