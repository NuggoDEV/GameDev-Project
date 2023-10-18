using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWarner : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    private float size;
    private float sizeChangeSpeed = 0.005f;
    Vector3 sizeChange;

    // Start is called before the first frame update
    void Start()
    {
        size = 0f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        sizeChange = new Vector3(1 + size, 0.001f, 1 + size);
        gameObject.transform.localScale = sizeChange;
        size = size + sizeChangeSpeed;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}

        

