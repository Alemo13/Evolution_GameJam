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
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;

        // Clamp the spawn position if it exceeds the limit
        float limit = 9f;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -limit, limit);
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, -limit, limit);

        return spawnPosition;
    }


    bool IsPositionOccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.005f, obstacleLayer); // Adjust radius as needed
        return colliders.Length > 0;
    }
}
