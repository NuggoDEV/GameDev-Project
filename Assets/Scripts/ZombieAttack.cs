using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject GameOverPanel;



    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GameObject.Find("Canvas/HPanel/HPslider").GetComponent<Slider>();
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
            //hpSlider.value = script.currentHP;
            Vector3 knockbackDealt = (other.transform.position - transform.position).normalized;
            other.GetComponent<CharacterController>().Move(knockbackDealt * knockback);

            }
        }
    }


