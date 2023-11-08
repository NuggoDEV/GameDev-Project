using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float attackRange = 1.0f;
    public GameObject player;
    public GameObject zombieAttack;
    public Transform attackingPart;
    public Transform rotate;
    private UnityEngine.AI.NavMeshAgent navAgent;
    public Rigidbody rb;
    public bool follow;
    public bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        follow = true; //The zombie starts active now
        attacking = false; //the zombie is not attackinig by default
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        transform.rotation.Set(0, player.transform.position.y, 0, 0);

        if (follow)
        {
            if (distance > attackRange & attacking == false) //The zombie chases the player until it is within range
            {
                navAgent.SetDestination(player.transform.position);
                navAgent.acceleration = 50;
                navAgent.isStopped = false;
            }

            else if (distance <= attackRange & attacking == false) //if the zombie is in range and isn't already attacking; attack
            {
                navAgent.acceleration = 50;
                navAgent.isStopped = true;
                StartCoroutine(Attack());
            }

            else //if the zombie is attacking, or something's gone wrong, the zombie stops
            {
                navAgent.acceleration = 50;
                navAgent.isStopped = true; //I'll write some more code here to get it to actually attack, placeholder for now - Code written
            }

            /*if (rotate != null)
            {
                transform.rotation.Set(0, player.transform.position.y, 0, 0);
            }*/
        } //If the zombie isn't chasinig the player, it'll do nothing

        else //if the zombie is attacking, or something's gone wrong, the zombie stops
        {
            navAgent.acceleration = 50;
            navAgent.isStopped = true; //I'll write some more code here to get it to actually attack, placeholder for now - Code written
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.other.tag == "Zombie")
        {
            int Enemy = LayerMask.NameToLayer("Enemy");
            gameObject.layer = Enemy;
        }
    }

    public IEnumerator Attack() //The actual attack procces of the zombie
    {
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        GameObject temp = Instantiate(zombieAttack, attackingPart.position, attackingPart.rotation);
        yield return new WaitForSeconds(1.0f);
        transform.LookAt(player.transform.position);
        attacking = false;
    }

    //When the player enters or exits the Zombie's detection range this tells the Zombie to chase or stop, respectively
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
    // I think i'll set up a second, smaller radius with its own object to get the zombies to attack the plants if they aren't chasing the player
    // that broke the script, I'ma just use the attack range
}
