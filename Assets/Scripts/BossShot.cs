using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    public int damage = 10;
    public float speed = 3.0f;
    public Unit script;
    public BattleSystem battleScript;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        script = FindObjectOfType<Unit>();
        battleScript = FindObjectOfType<BattleSystem>();
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

    void FixedUpdate()
    {
        transform.Translate(Vector3.back / 3 * speed);
        speed = speed + Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BossShot hit");
        if (other.tag == "Player")
        {
            script = other.GetComponent<Unit>();
            script.currentHP = script.currentHP - damage;
            if (script.currentHP <= 0)  //Once we have an enemy attack coded in move this script to there, to check  if the player is dead
            {
                battleScript.GameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Destroy(gameObject);
        }
        else if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
