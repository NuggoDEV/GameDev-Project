using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BossScript : MonoBehaviour
{

    public GameObject bossCore;
    public GameObject bossFist;
    public GameObject bossGun;
    public GameObject zombieBits;
    public float maxHP = 100;
    public float currentHP;
    private float xOffset;
    public bool attacking;
    public bool shielded;
    public bool secondKill;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        var bits = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ZombieBit.prefab", typeof(GameObject));
        zombieBits = bits as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0 && secondKill == false)
        {
            transform.Translate(0.0f, 0.0f, 0.0f);
            for (int i = 0; i < 40; i++)
            {
                xOffset = Random.Range(-1, 1);
                Instantiate(zombieBits, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), transform.rotation);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BossHit");
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Boss Damaged");
            if (collision.gameObject.name == "Pea(Clone)")
            {
                Pea script = collision.gameObject.GetComponent<Pea>();
                currentHP = currentHP - script.damage;
            }
            else if (collision.gameObject.name == "Chomp(Clone)")
            {
                Chomp script = collision.gameObject.GetComponent<Chomp>();
                currentHP = currentHP - script.damage * 200;
                Debug.Log("Holy Shit how did you do that");
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
