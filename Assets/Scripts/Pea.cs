using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    public int damage = 4;
    public float stun = 0.6f;
    public float knockback = 0.1f;
    public float speed = 3.0f;
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
        
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pea hit something");
        Destroy(gameObject);
    }
}
