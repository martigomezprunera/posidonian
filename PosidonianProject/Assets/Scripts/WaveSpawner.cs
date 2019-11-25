using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    #region VARIABLES
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;
    private float countdown = 2f;


    public Text waveCountdownText;

    private int waveIndex = 0;
    

    #endregion

    #region UPDATE
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    #endregion

    #region SPAWN WAVE

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
    #endregion

    #region SPAWN ENMEY
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    #endregion
}
