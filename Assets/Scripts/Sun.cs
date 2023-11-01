using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sun : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        /*Debug.Log("hello");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collected");
            GameObject.Find("GameManager").GetComponent<GameManager>().Sun += 1;
            Destroy(this);
        }*/
    }
}
