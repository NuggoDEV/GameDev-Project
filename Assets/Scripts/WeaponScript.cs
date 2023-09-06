using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectile; //This is the projectile
    public float force; //the speed of the projectile
    public string weaponName = "Peashooter"; //the number of the weapon, to tell the weaponManager which weapon to find.
    public bool attack = false; //is the peashooter attacking?

    // Start is called before the first frame update
    void Start()
    {
        var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pea.prefab", typeof(GameObject));
        projectile = prefab as GameObject;

        if (weaponName == "Peashooter")
        {
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}

