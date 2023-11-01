using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BossFist : MonoBehaviour
{
    public GameObject bossCore;
    public GameObject fist;
    public GameObject player;
    public GameObject target;
    public GameObject zombieBits;
    public GameObject AoE1;
    public GameObject AoE2;
    public GameObject AoE3;
    public GameObject slamSpot;
    public GameObject tantrumSpot;
    public GameObject strikeSpot;
    public GameObject strikeSpot2;
    public GameObject warnerSpawner;
    public GameObject strikeWarner;
    public float maxHP = 50;
    public float currentHP;
    public float damage = 30;
    private float xOffset;
    public bool punch;
    public bool slam;
    public bool tantrum;

    // Start is called before the first frame update
    void Start()
    {
        bossCore = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.Find("TrackerFist");
        warnerSpawner = GameObject.Find("WarnerSpawner");
        currentHP = maxHP;
        //var bits = 
         //   .LoadAssetAtPath("Assets/Prefabs/ZombieBit.prefab", typeof(GameObject));
        //zombieBits = bits as GameObject;
        //var striker = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/StrikeWarner.prefab", typeof(GameObject));
        //strikeWarner = striker as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FistHit");
        if (collision.gameObject.tag == "Player")
        {
            Unit script = collision.gameObject.GetComponent<Unit>();
            script.currentHP = script.currentHP - damage;
        }
        else if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Fist Damaged");
            if (collision.gameObject.name == "Pea(Clone)")
            {
                Pea script = collision.gameObject.GetComponent<Pea>();
                currentHP = currentHP - script.damage;
                script.lifeTime = 0;
            }
            else if (collision.gameObject.name == "Chomp(Clone)")
            {
                Chomp script = collision.gameObject.GetComponent<Chomp>();
                currentHP = currentHP - script.damage;
                Debug.Log("Holy Shit how did you do that");
            }
            else if (collision.gameObject.name == "Melon(Clone)")
            {
                Melon script = collision.gameObject.GetComponent<Melon>();
                currentHP = currentHP - script.damage;
                script.lifeTime = 0;
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

    // current idea is to have three attacks; a punch with a moderate AoE that create some debri, a slam with the gun which has a large AoE and large debri
    // and a tantrum once it reaches its second state that strikes four places in front of it repeatedly with both weapons
}
