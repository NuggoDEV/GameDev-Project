using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHitbox : MonoBehaviour
{
    public GameObject zombieCore;
    public float maxHP = 10;
    public float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 1)
        {
            Destroy(zombieCore);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ZombieHit");
        if (collision.gameObject.tag == "Pea")
        {
            Debug.Log("Zombie Damaged");
            currentHP = currentHP - 4;
        }
    }
}
