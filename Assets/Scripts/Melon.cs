using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Melon : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    public int damage = 4;
    public float stun = 0.6f;
    public float knockback = 0.1f;
    public float speed = 3.0f;
    public LayerMask weaponMask;
    public GameObject bomb;
    Collision2D weaponCollider;
    Rigidbody rb;
    PlayerMovement script;
    public GameObject player;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
        //var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/MelonBomb.prefab", typeof(GameObject));
        bomb = prefab;// as GameObject;
        player = GameObject.Find("PlayerBody");
        script = player.GetComponent<PlayerMovement>();
        script.lockCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= lifeTime)
        {
            GameObject temp = Instantiate(bomb, gameObject.transform.position, gameObject.transform.rotation);
            script.lockCamera = false;
            Destroy(gameObject);
        }

        rb.velocity = transform.forward * speed;
        speed = speed + 0.02f;

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject temp = Instantiate(bomb, gameObject.transform.position, gameObject.transform.rotation);
            script.lockCamera = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Melon hit something");
        GameObject temp = Instantiate(bomb, gameObject.transform.position, gameObject.transform.rotation);
        script.lockCamera = false;
        Destroy(gameObject);
    }
}
