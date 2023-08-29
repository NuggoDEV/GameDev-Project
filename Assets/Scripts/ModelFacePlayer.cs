using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFacePlayer : MonoBehaviour
{
    public GameObject playerCore;
    public GameObject self;


    // Start is called before the first frame update
    void Start()
    {
        playerCore = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCore.transform);
    }
}
