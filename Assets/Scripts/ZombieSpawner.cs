using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spitter;
    public GameObject enemySpawner;
    public GameObject[] enemyCounter;
    public GameObject gameManager;
    public WaveManager waveScript;
    public float spawnCounter;
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
            if (spawnCounter < 5)
            {
                Instantiate(zombie, new Vector3(enemySpawner.transform.position.x + xOffset, enemySpawner.transform.position.y, enemySpawner.transform.position.z), enemySpawner.transform.rotation);
                spawnCounter++;
            }

            else if ( spawnCounter == 5)
            {
                Instantiate(spitter, new Vector3(enemySpawner.transform.position.x + xOffset, enemySpawner.transform.position.y, enemySpawner.transform.position.z), enemySpawner.transform.rotation);
                spawnCounter = 0;
            }
        }
    }

    // FixedUpdate is called very fast
    void FixedUpdate()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Zombie"); //continously checks how many zombies exist
        xOffset = Random.Range(-10, 10);

        if (enemyCounter.Length <= 0)
        {
            waveScript.FinishWave(false);
        }
    }
}
