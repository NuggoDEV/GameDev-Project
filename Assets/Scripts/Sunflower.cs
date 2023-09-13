using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public int Amount_of_Sun; 
    public GameObject sun;
    public float timer = 0;
    public float waitTime = 5f;

     void Update()
     {
        timer = timer + Time.deltaTime;
        if (timer > waitTime)
        {
            //Debug.Log("sun");
            Instantiate(sun, transform.position, transform.rotation);

            timer = timer - waitTime;
        }
     }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "sun")
        {
            Amount_of_Sun += 1; //sun amount goes up by one
            Destroy(sun);
        }
    }
}
