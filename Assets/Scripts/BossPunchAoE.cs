using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPunchAoE : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    private float size;
    public int damage = 10;
    public float sizeChangeSpeed = 0.002f;
    Vector3 sizeChange;
    public Unit script;
    public BattleSystem battleScript;

    // Start is called before the first frame update
    void Start()
    {
        size = 0f;
        timer = 0;
        script = FindObjectOfType<Unit>();
        battleScript = FindObjectOfType<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (size < 15)
        {
            sizeChange = new Vector3(15 - size, 15 - size, 15 - size);
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BossShotAoE hit");
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
    }
}
