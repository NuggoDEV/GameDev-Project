using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterMovement : MonoBehaviour
{
    public float attackRange = 4.0f;
    public GameObject player;
    public GameObject spitterAttack;
    public Transform attackingPart;
    public Transform rotate;
    private UnityEngine.AI.NavMeshAgent navAgent;
    public Rigidbody rb;
    public bool follow;
    public bool attacking;
    public float attackRecover;
    public float burstSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        follow = true; //The spitter starts active now
        attacking = false; //the spitter is not attackinig by default
        attackRecover = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        attackRecover = attackRecover - Time.deltaTime;

        /*if (attackRecover <= 0)
        {
            attacking = false;
        }
        else
        {
            attacking = true;
        }*/ // removed for the time being, managed to work the burst and look feature into the coroutine itself

        transform.rotation.Set(0, player.transform.position.y, 0, 0);

        if (follow)
        {
            if (distance > attackRange & attacking == false) //The spitter chases the player until it is within range
            {
                navAgent.SetDestination(player.transform.position);
                navAgent.acceleration = 5;
                navAgent.isStopped = false;
            }

            else if (distance <= attackRange & attacking == false) //if the spitter is in range and isn't already attacking; attack
            {
                navAgent.acceleration = 50;
                navAgent.isStopped = true;
                StartCoroutine(Attack());
            }

            else //if the spitter is attacking, or something's gone wrong, the spitter stops
            {
                transform.rotation.Set(0, player.transform.position.y, 0, 0);
                navAgent.acceleration = 50;
                navAgent.isStopped = true; //I'll write some more code here to get it to actually attack, placeholder for now - Code written
            }
        } //If the spitter isn't chasinig the player, it'll do nothing
    }

    public IEnumerator Attack() //The actual attack procces of the spitter
    {
        Debug.Log("Spitter Attacks");
        //rb.velocity = new Vector3(0, 0, 0);
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(player.transform.position);
        for (int i = 0; i < burstSize; i++)
        {
            GameObject temp = Instantiate(spitterAttack, attackingPart.position, attackingPart.rotation);
            yield return new WaitForSeconds(0.01f);
            transform.LookAt(player.transform.position);
        }
        yield return new WaitForSeconds(2f);
        attacking = false;
        //attackRecover = 2; // removed for the time being, managed to work the burst and look feature into the coroutine itself
        Debug.Log("Spitter recovers");
    }

    //When the player enters or exits the spitter's detection range this tells the spitter to chase or stop, respectively
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In Range");
            follow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Left Range");
            follow = false;
        }

    }*/ //removing this for the time being
    // I think i'll set up a second, smaller radius with its own object to get the spitters to attack the plants if they aren't chasing the player
    // that broke the script, I'ma just use the attack range
}
