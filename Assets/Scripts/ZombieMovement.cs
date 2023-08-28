using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float attackRange = 1.0f;
    public GameObject player;
    public Transform rotate;
    private UnityEngine.AI.NavMeshAgent navAgent;
    public Rigidbody rigidBody;
    public bool follow;
    public bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        follow = false; //The zombie starts inactive, waiting for the player to enter its chase range
        attacking = false; //the zombie is not attackinig by default
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if (follow == true)
        {
            if (distance > attackRange & attacking == false) //The zombie chases the player until it is within range
            {
                navAgent.SetDestination(player.transform.position);
                navAgent.isStopped = false;
            }

            else
            {
                navAgent.isStopped = true; //I'll write some more code here to get it to actually attack, placeholder for now
            }

            if (rotate != null)
            {
                rotate.LookAt(player.transform);
            }
        } //If the zombie isn't chasinig the player, it'll do nothing
    }

    //When the player enters or exits the Zombie's detection range this tells the Zombie to chase or stop, respectively
    private void OnTriggerEnter(Collider other)
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

    }
    // I think i'll set up a second, smaller radius with its own object to get the zombies to attack the plants if they aren't chasing the player
}
