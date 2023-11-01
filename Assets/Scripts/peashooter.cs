using UnityEngine;

public class peashooter : MonoBehaviour
{
    public GameObject Coins;
    public float timer = 0;
    public float waitTime = 5f;

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > waitTime)
        {
            //Debug.Log("sun");
            Instantiate(Coins, new Vector3(transform.position.x + -2f, transform.position.y, transform.position.z), transform.rotation);

            timer = timer - waitTime;
        }
    }

}
