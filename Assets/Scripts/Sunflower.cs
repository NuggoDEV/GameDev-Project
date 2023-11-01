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
            Instantiate(sun, new Vector3(transform.position.x + -2f, transform.position.y, transform.position.z), transform.rotation);

            timer = timer - waitTime;
        }
     }

    
}
