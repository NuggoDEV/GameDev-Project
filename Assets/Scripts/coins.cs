using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("COllided with player");
            //Debug.Log("collected");
            GameObject.Find("GameManager").GetComponent<GameManager>().Coins += 1;
            Destroy(gameObject);
        }
    }
}
