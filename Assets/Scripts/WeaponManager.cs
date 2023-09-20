using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public WeaponScript weaponScript;
    public Transform spawnTransform; //Where the projectile is fired from
    public bool attack = false;


    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon"); //default weapon is peashooter
        weaponScript = weapon.GetComponent<WeaponScript>(); //access the weapon's script

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {

        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire!");
            GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
            attack = true;
        }
        else
        {
            return;
        }
    }
}
