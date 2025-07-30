using System.Collections.Generic;
using UnityEngine;

public class CoinPatternSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform player;

    [Header("Coin Spawn Settings")]
    public float spawnInterval = 2f;
    public float coinDestroyDistance = 10f;
    public float minY = -2f;
    public float maxY = 3f;

    [Header("Coin Movement")]
    public float coinMoveSpeed = 5f;

    private float timer = 0f;
    private List<GameObject> activeCoins = new List<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // Randomly choose line or cluster
            if (Random.value < 0.6f)
                SpawnStraightLine();
            else
                SpawnCluster();
        }

        // Move all active coins left
        for (int i = activeCoins.Count - 1; i >= 0; i--)
        {
            GameObject coin = activeCoins[i];
            if (coin == null)
            {
                activeCoins.RemoveAt(i);
                continue;
            }

            // Move left
            coin.transform.Translate(Vector3.left * coinMoveSpeed * Time.deltaTime);

            // Destroy if behind player
            if (coin.transform.position.x < player.position.x - coinDestroyDistance)
            {
                Destroy(coin);
                activeCoins.RemoveAt(i);
            }
        }
    }

    void SpawnStraightLine()
    {
        int count = Random.Range(3, 7);
        float spacing = 1f;
        float yPos = Random.Range(minY, maxY);
        float xStart = player.position.x + 10f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(xStart + i * spacing, yPos, 0f);
            GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            activeCoins.Add(coin);
        }
    }

    void SpawnCluster()
    {
        int rows = Random.Range(2, 4);
        int cols = Random.Range(2, 4);
        float spacing = 1f;
        float baseX = player.position.x + 10f;
        float baseY = Random.Range(minY, maxY);

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 pos = new Vector3(baseX + x * spacing, baseY + y * spacing, 0f);
                GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
                activeCoins.Add(coin);
            }
        }
    }
}
