using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFacePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation.Set(0, player.transform.position.y, 0, 0);
    }
}
