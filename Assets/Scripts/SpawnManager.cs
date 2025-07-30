using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject enemyPrefab;
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;

    public float minY = 0f;
    public float maxY = 4f;
    public float spawnX = 25f;
    public float spawnZ = 0f;
    private float enemySpawnDelay = 3f;
    private float enemyRepeatRate = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemyRepeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void SpawnEnemy()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 enemySpawnPos = new Vector3(35f, Random.Range(6f, 15f), 0f);
            Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
        }
    }
    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(spawnX, randomY, spawnZ);

            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
