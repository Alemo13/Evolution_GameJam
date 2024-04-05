using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRadius = 10f;
    public LayerMask obstacleLayer;

    public int maxAttempts = 10;

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            if (!IsPositionOccupied(spawnPosition))
            {
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
                // You can instantiate more coins or break the loop here based on your requirements.
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        return new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1f, obstacleLayer); // Adjust radius as needed
        return colliders.Length > 0;
    }
}
