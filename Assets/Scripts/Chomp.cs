using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomp : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    public int damage = 10;
    public float stun = 0.6f;
    public float knockback = 2f;
    public LayerMask weaponMask;
    Collision2D weaponCollider;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
        }
    }
}
