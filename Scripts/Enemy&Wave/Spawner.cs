using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnPoint;
    public Text waveCount;
    public GameManager gameManager;

    public static int enemyAlive = 0;
    private int waveIndex = 0;
    
    public float timeBetweenSpawn = 5f;
    private float spawnTime = 5f;

    private void Start()
    {
        enemyAlive = 0;
    }
    void Update()
    {
        if (enemyAlive > 0)
            return;

        if(waveIndex == waves.Length && enemyAlive <= 0)
        {
            gameManager.LevelCleared();
            this.enabled = false;
        }

        if (spawnTime <= 0f && enemyAlive == 0)
        {
            StartCoroutine(SpawnWave());
            spawnTime = timeBetweenSpawn;
            return;
        }
        spawnTime -= Time.deltaTime;

        waveCount.text = $"Wave:{waveIndex+1}";
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        enemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;
    }
    
    void SpawnEnemy(GameObject _enemyPrefab)
    {
        Instantiate(_enemyPrefab,spawnPoint.position,Quaternion.identity);
    }
}
