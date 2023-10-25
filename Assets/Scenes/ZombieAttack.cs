using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAttack : MonoBehaviour
{
    public float swingTime = 0.2f;
    private float timer;
    public float damage = 4;
    public float knockback = 2;
    public Unit script;
    public BattleSystem battleScript;
    public Slider hpSlider;



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
        if (timer >= swingTime)
        {
            Destroy(gameObject);
        }
    }
    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            script = other.GetComponent<Unit>();
            script.currentHP = script.currentHP - damage;
            Debug.Log(script.currentHP + " HP");
            hpSlider.value = script.currentHP;
            Vector3 knockbackDealt = (other.transform.position - transform.position).normalized;
            other.GetComponent<CharacterController>().Move(knockbackDealt * knockback);
            if (script.currentHP <= 0)  //Once we have an enemy attack coded in move this script to there, to check  if the player is dead
            {
                battleScript.GameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

}
