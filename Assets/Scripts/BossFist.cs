using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFist : MonoBehaviour
{
    public GameObject bossCore;
    public GameObject gun;
    public GameObject fist;
    public GameObject player;
    public GameObject target;
    public GameObject zombieBits;
    public GameObject punchAoE;
    public GameObject slamSpot;
    public GameObject slamWaitSpot;
    public GameObject punchSpot;
    public GameObject restSpot;
    public GameObject warnerSpawner;
    public GameObject strikeWarner;
    public float maxHP = 50;
    public float currentHP;
    public float speed = 12.0f;
    public float damage = 30;
    public float punchSize = 3f;
    private float xOffset;
    public bool punch;
    public bool returning;
    public bool readied;
    public bool slamReady;
    public BossGun gunScript;
    public BossScript bossScript;
    Vector3 goUp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.Find("TrackerFist");
        warnerSpawner = GameObject.Find("WarnerSpawner");
        currentHP = maxHP;
        transform.position = restSpot.transform.position;
        gunScript = gun.GetComponent<BossGun>();
        bossScript = bossCore.GetComponent<BossScript>();
        readied = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (returning)
        {
            speed = 25f;
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, restSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, restSpot.transform.position) < 0.001f)
            {
                returning = false;
                readied = true;
                speed = 14f;
            }
        }
        else if (punch)
        {
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, punchSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, punchSpot.transform.position) < 0.001f)
            {
                punch = false;
                StartCoroutine(Punch());
            }
        }
        else if (gunScript.slam == true)
        {
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, slamWaitSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, slamWaitSpot.transform.position) < 0.001f)
            {
                slamReady = true;
            }
        }
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
                bossScript.currentHP -= script.damage;
                script.lifeTime = 0;
            }
            else if (collision.gameObject.name == "Chomp(Clone)")
            {
                Chomp script = collision.gameObject.GetComponent<Chomp>();
                currentHP = currentHP - script.damage;
                bossScript.currentHP -= script.damage;
            }
            else if (collision.gameObject.name == "Melon(Clone)")
            {
                Melon script = collision.gameObject.GetComponent<Melon>();
                currentHP = currentHP - script.damage;
                bossScript.currentHP -= script.damage;
                script.lifeTime = 0;
            }
            else if (collision.gameObject.name == "MelonBomb(Clone)")
            {
                MelonBomb script = collision.gameObject.GetComponent<MelonBomb>();
                currentHP = currentHP - script.damage;
                bossScript.currentHP -= script.damage;
            }
            else
            {
                Debug.Log("Collider Error");
            }
        }
    }

    public IEnumerator Punch()
    {
        Debug.Log("Boss Punches");
        yield return new WaitForSeconds(1f);
        transform.Translate(0.0f, 0.0f, 0.0f);
        for (int i = 0; i < punchSize; i++)
        {
            GameObject temp = Instantiate(strikeWarner, warnerSpawner.transform.position, warnerSpawner.transform.rotation);
            yield return new WaitForSeconds(1f);
            while (Vector3.Distance(transform.position, temp.transform.position) > 0.001f)
            {
                yield return new WaitForSeconds(0.2f);
                transform.position = Vector3.MoveTowards(transform.position, temp.transform.position, 10f);
            }
            GameObject temp2 = Instantiate(punchAoE, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
            goUp = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, goUp, speed);
            yield return new WaitForSeconds(0.1f);
            goUp = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, goUp, speed);
            yield return new WaitForSeconds(0.1f);
            goUp = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, goUp, speed);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2f);
        returning = true;
        speed = 14.0f;
        Debug.Log("Boss stops Punching");
    }

    // current idea is to have three attacks; a punch with a moderate AoE that create some debri, a slam with the gun which has a large AoE and large debri
    // and a tantrum once it reaches its second state that strikes four places in front of it repeatedly with both weapons
}
