using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public GameObject spawnWeapon;
    public WeaponScript weaponScript;
    public Transform spawnTransform; //Where the projectile is fired from
    public Transform weaponTransform;
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
        if (Input.GetKeyDown("1"))
        {
            Destroy(weapon);
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Weapons/HeldPeashooter.prefab", typeof(GameObject));
            spawnWeapon = prefab as GameObject;
            weapon = Instantiate(spawnWeapon, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }

        if (Input.GetKeyDown("2"))
        {
            Destroy(weapon);
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Weapons/HeldChomper.prefab", typeof(GameObject));
            spawnWeapon = prefab as GameObject;
            weapon = Instantiate(spawnWeapon, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }

        if (Input.GetKeyDown("3"))
        {
            Destroy(weapon);
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Weapons/HeldMelon.prefab", typeof(GameObject));
            spawnWeapon = prefab as GameObject;
            weapon = Instantiate(spawnWeapon, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }


        if (Input.GetButtonDown("Fire1"))
        {
            if (weaponScript.projectile.tag == "Projectile")
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
            }
            else if (weaponScript.projectile.tag == "Melee")
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
            }
            Debug.Log("Fire!");
            attack = true;
        }
        else
        {
            return;
        }
    }
}
