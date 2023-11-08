using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spitter;
    public GameObject enemySpawner;
    public GameObject[] enemyCounter;
    public GameObject gameManager;
    public GameObject boss;
    public GameObject bossSpawn;
    public WaveManager waveScript;
    public float spawnCounter;
    private float timer = 0;
    private float xOffset;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        waveScript = gameManager.GetComponent<WaveManager>();
        waveScript.startWave += StartWave;
        enemySpawner.transform.Translate(0.0f, 0.0f, 0.0f);
    }

    void StartWave(int wave, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 enemyPos = enemySpawner.transform.position;
            Instantiate(spawnCounter == 5 ? spitter : zombie, new Vector3(enemyPos.x + xOffset, enemyPos.y, enemyPos.z), enemySpawner.transform.rotation);
            spawnCounter = spawnCounter == 5 ? 0 : spawnCounter + 1;
        }
        if (waveScript.wave == 10)
        {
            Instantiate(boss, bossSpawn.transform.position, bossSpawn.transform.rotation);
        }
    }

    // FixedUpdate is called very fast
    void FixedUpdate()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Zombie"); //continously checks how many zombies exist
        xOffset = Random.Range(-10, 10);
        Debug.Log(enemyCounter.Length);
        if (enemyCounter.Length <= 0)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 5)
            {
                waveScript.FinishWave();
                timer = 0;
            }
        }
    }
}
