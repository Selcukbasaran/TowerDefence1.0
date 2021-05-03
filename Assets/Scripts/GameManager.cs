using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnpoint;



    public float timeBetweenWaves = 3f;
    private float countdown = 2f;

    private int wavenum = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        Debug.Log("Wave Incoming");
        for (int i = 0; i < wavenum; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);// spawn etme
    }
}