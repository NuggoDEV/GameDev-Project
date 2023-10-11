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
    public float reload1 = 0;
    public float reload2 = 0;
    public float reload3 = 0;


    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon"); //default weapon is peashooter
        weaponScript = weapon.GetComponent<WeaponScript>(); //access the weapon's script
    }

    // Update is called once per frame
    void Update()
    {
        reload1 = reload1 - Time.deltaTime;
        reload2 = reload2 - Time.deltaTime;
        reload3 = reload3 - Time.deltaTime;

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
            if (weaponScript.projectile.name == "Pea" && reload1 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload1 = weaponScript.cooldown;
            }
            else if (weaponScript.projectile.name == "Chomp" && reload2 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload2 = weaponScript.cooldown;
            }
            else if (weaponScript.projectile.name == "Melon" && reload3 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload3 = weaponScript.cooldown;
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
