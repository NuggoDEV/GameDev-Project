using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    public GameObject boss;
    public GameObject gun;
    public GameObject fist;
    public GameObject player;
    public GameObject target;
    public GameObject zombieBits;
    public GameObject shootShot;
    public GameObject beamShot;
    public GameObject slamSpot;
    public GameObject slamWaitSpot;
    public GameObject slamStrike;
    public GameObject slamAoE;
    public GameObject shootSpot;
    public GameObject beamSpot;
    public GameObject restSpot;
    public GameObject warnerSpawner;
    public GameObject strikeWarner;
    public float maxHP = 50f;
    public float currentHP;
    public float speed = 14f;
    public float beamSize = 30f;
    public float burstSize = 3f;
    public float choice;
    public float secondChoice;
    private float xOffset;
    public bool shoot;
    public bool beam;
    public bool slam;
    public bool returning;
    public bool ready;
    public BossFist fistScript;
    public BossScript bossScript;
    Vector3 playerSpot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.Find("TrackerGun");
        warnerSpawner = GameObject.Find("WarnerSpawner");
        currentHP = maxHP;
        transform.position = restSpot.transform.position;
        fistScript = fist.GetComponent<BossFist>();
        bossScript = boss.GetComponent<BossScript>();
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready && fistScript.readied)
        {
            StartCoroutine(Decide());
            ready = false;
            fistScript.readied = false;
        }
        else if (returning)
        {
            speed = 25f;
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, restSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, restSpot.transform.position) < 0.001f)
            {
                returning = false;
                ready = true;
                speed = 14f;
            }
        }
        else if (slam)
        {
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, slamWaitSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, slamWaitSpot.transform.position) < 0.001f && fistScript.slamReady)
            {
                slam = false;
                StartCoroutine(Slam());
            }
        }
        else if (shoot)
        {
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, shootSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, shootSpot.transform.position) < 0.001f)
            {
                shoot = false;
                StartCoroutine(Shoot());
            }
        }
        else if (beam)
        {
            var shift = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, beamSpot.transform.position, shift);

            if (Vector3.Distance(transform.position, beamSpot.transform.position) < 0.001f)
            {
                beam = false;
                StartCoroutine(Beam());
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FistHit");
        if (collision.gameObject.tag == "Projectile")
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

    public IEnumerator Decide()
    {
        Debug.Log("Boss is thinking...");
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        choice = Random.Range(0, 3);
        secondChoice = Random.Range(0, 2);
        Debug.Log("Boss Decided..." + choice + secondChoice);
        if (choice == 0f)
        {
            if (secondChoice == 0f) 
            {
                ready = true;
                fistScript.readied = true;
            }
            else if (secondChoice > 0f)
            {
                fistScript.punch = true;
                fistScript.readied = false;
                ready = true;
            }
        }
        else if (choice == 1f)
        {
            if (secondChoice == 0f)
            {
                shoot = true;
                ready = false;
                fistScript.readied = true;
            }
            else if (secondChoice > 0f)
            {
                shoot = true;
                fistScript.punch = true;
                fistScript.readied = false;
                ready = false;
            }
        }
        else if (choice == 2f)
        {
            if (secondChoice == 0f)
            {
                beam = true;
                ready = false;
                fistScript.readied = true;
            }
            else if (secondChoice > 0f)
            {
                beam = true;
                fistScript.punch = true;
                fistScript.readied = false;
                ready = false;
            }
        }
        else if (choice == 3f)
        {
            slam = true;
            ready = false;
            fistScript.readied = false;
        }
    }

    public IEnumerator Slam()
    {
        Debug.Log("Boss slams!");
        GameObject temp = Instantiate(strikeWarner, slamSpot.transform.position, slamSpot.transform.rotation);
        GameObject temp1 = Instantiate(strikeWarner, fistScript.slamSpot.transform.position, fistScript.slamSpot.transform.rotation);
        yield return new WaitForSeconds(3f);
        transform.Translate(0.0f, 0.0f, 0.0f);
        while (Vector3.Distance(transform.position, slamSpot.transform.position) > 0.001f)
        {
            yield return new WaitForSeconds(0.1f);
            transform.position = Vector3.MoveTowards(transform.position, slamSpot.transform.position, 5f);
            fist.transform.position = Vector3.MoveTowards(transform.position, fistScript.slamSpot.transform.position, 5f);
        }
        GameObject shot1 = Instantiate(shootShot, transform.position, transform.rotation);
        GameObject shot2 = Instantiate(shootShot, slamStrike.transform.position, transform.rotation);
        GameObject shot3 = Instantiate(shootShot, fistScript.slamSpot.transform.position, fistScript.slamSpot.transform.rotation);
        yield return new WaitForSeconds(5f);
        returning = true;
        fistScript.returning = true;
        Debug.Log("Slam Over");

    }

    public IEnumerator Shoot()
    {
        Debug.Log("Boss uses Gun");
        yield return new WaitForSeconds(1f);
        transform.Translate(0.0f, 0.0f, 0.0f);
        for (int i = 0; i < burstSize; i++)
        {
            playerSpot = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerSpot, 100f);
            GameObject temp = Instantiate(shootShot, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(2f);
        returning = true;
        Debug.Log("Shoot attack over");
    }

    public IEnumerator Beam()
    {
        Debug.Log("Boss uses Beam");
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < beamSize; i++)
        {
            GameObject temp = Instantiate(beamShot, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        returning = true;
        Debug.Log("Beam attack over");
    }
}
