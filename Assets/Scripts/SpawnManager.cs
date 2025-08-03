using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // This script manages the spawning of obstacles and enemies in the game
    // It uses InvokeRepeating to spawn obstacles and enemies at specified intervals
    // Adjust the spawn positions and intervals as needed

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

    // Start is called before the first frame update
    // This method initializes the spawning of obstacles and enemies
    // It uses InvokeRepeating to call the SpawnObstacle and SpawnEnemy methods at specified intervals
    // The PlayerController script is used to check if the game is over before spawning
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemyRepeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // This method spawns an enemy at a random height within specified limits
    // It checks if the game is over before spawning
    void SpawnEnemy()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 enemySpawnPos = new Vector3(35f, Random.Range(6f, 15f), 0f);
            Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
        }
    }

    // This method spawns an obstacle at a random height within specified limits
    // It checks if the game is over before spawning
    // The obstacle prefab is instantiated at the specified spawn position
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
