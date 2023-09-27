using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZombieHitbox : MonoBehaviour
{
    public GameObject zombieCore;
    public GameObject zombieBits;
    public float maxHP = 10;
    public float currentHP;
    private float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ZombieBit.prefab", typeof(GameObject));
        zombieBits = prefab as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 1)
        {
            transform.Translate(0.0f, 0.0f, 0.0f);
            for(int i = 0; i < 10; i++)
            {
                xOffset = Random.Range(-1, 1);
                Instantiate(zombieBits, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), transform.rotation);
            }
            Destroy(zombieCore);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ZombieHit");
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Zombie Damaged");
            if (collision.gameObject.name == "Pea(Clone)")
            {
                Pea script = collision.gameObject.GetComponent<Pea>();
                currentHP = currentHP - script.damage;
            }
            else if (collision.gameObject.name == "Chomp(Clone)")
            {
                Chomp script = collision.gameObject.GetComponent<Chomp>();
                currentHP = currentHP - script.damage;
            }
            else if (collision.gameObject.name == "Melon(Clone)")
            {
                Melon script = collision.gameObject.GetComponent<Melon>();
                currentHP = currentHP - script.damage;
            }
            else if (collision.gameObject.name == "MelonBomb(Clone)")
            {
                MelonBomb script = collision.gameObject.GetComponent<MelonBomb>();
                currentHP = currentHP - script.damage;
            }
            else
            {
                Debug.Log("Collider Error");
            }
        }
    }
}
