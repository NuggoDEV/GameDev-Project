using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    public BossScript script;
    public float size;
    Vector3 sizeChange;

    // Start is called before the first frame update
    void Start()
    {
        script = boss.GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        size = script.currentHP / 500f;
        sizeChange = new Vector3(size, 0.1f, 0.1f);
        gameObject.transform.localScale = sizeChange;
    }
}
