using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonBomb : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    private float size;
    public int damage = 10;
    public float stun = 0.6f;
    public float knockback = 0.4f;
    public float sizeChangeSpeed = 0.002f;
    public LayerMask weaponMask;
    Vector3 sizeChange;
    Collision2D weaponCollider;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        size = 0f;
        timer = 0;
        rb = GetComponent<Rigidbody>();
    }

        // Update is called once per frame
        void Update()
    {
        timer = timer + Time.deltaTime;
        if (size < 8)
        {
            sizeChange = new Vector3(8 - size, 8 - size, 8 - size);
            gameObject.transform.localScale = sizeChange;
            size = size + sizeChangeSpeed;
        }
        else if (size >= 8)
        {
            Destroy(gameObject);
        }

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
        }
    }
}
