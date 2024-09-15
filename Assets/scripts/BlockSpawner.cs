using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Power-up gameobjects
    public GameObject SlowMotionPowerUp;
    public GameObject ShieldPowerUp;
    public GameObject HealthPowerUp;
    public GameObject DashPowerUp;

    public Player player;

    public float initialSpawnRate = 1f;         // Initial spawn rate for enemies
    public float minSpawnRate = 0.1f;           // Minimum spawn rate limit for enemies
    public float difficultyIncreaseRate = 0.95f; // Rate at which spawn rate decreases over time

    public float powerUpSpawnChance = 0.1f;     // 10% chance to spawn power-up per enemy spawn
    public float powerUpSpawnRate = 5f;         // Time interval between power-up spawns

    private float currentSpawnRate;
    private float nextSpawn = 0f;
    private int numberOfSpawns = 0;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + currentSpawnRate;
            float chance = Random.Range(0f, 1f);
            if (chance <= powerUpSpawnChance)
            {
                SpawnRandomPowerUp();
            }
            else
                SpawnBlocks();
            numberOfSpawns++;

            if (numberOfSpawns % 10 == 0)
            {
                IncreaseDifficulty();
            }

        }
    }

    void SpawnBlocks()
    {
        float randomX = Random.Range(-8, 8);
        Vector3 spawnPosition = new(randomX, transform.position.y, 0);
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        currentSpawnRate = Mathf.Max(currentSpawnRate * difficultyIncreaseRate, minSpawnRate);
    }

    // Spawns a random power-up from available power-ups
    void SpawnRandomPowerUp()
    {
        // Randomly select a power-up to spawn
        int randomIndex = Random.Range(0, 3); // Assuming we have 3 power-ups
        GameObject powerUpToSpawn = HealthPowerUp;

        switch (randomIndex)
        {
            case 0:
                powerUpToSpawn = SlowMotionPowerUp;
                break;
            case 1:
                powerUpToSpawn = ShieldPowerUp;
                break;
            case 2:
                powerUpToSpawn = HealthPowerUp;
                break;
        }

        // Choose a random spawn position for the power-up
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new(randomX, transform.position.y, 0);

        // Instantiate the selected power-up
        Instantiate(powerUpToSpawn, spawnPosition, Quaternion.identity);
    }
}
