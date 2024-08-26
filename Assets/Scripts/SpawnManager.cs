using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public GameObject boss;         // The boss GameObject to activate after all enemies are destroyed

    private int totalEnemies = 30; // Total number of enemies to spawn
    private int enemiesPerWave = 10; // Number of enemies to spawn per wave
    private float spawnStartDelay = 10;

    public Vector2 spawnAreaMin = new Vector2(-20f, -20f); // Minimum bounds of the spawn area (x, z)
    public Vector2 spawnAreaMax = new Vector2(20f, 20f); // Maximum bounds of the spawn area (x, z)

    private int spawnedEnemiesCount = 0; // Counter for spawned enemies
    private int destroyedEnemiesCount = 0; // Counter for destroyed enemies

    void Start()
    {
        boss.SetActive(false); // Ensure the boss is inactive at the start
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnStartDelay);
        while (spawnedEnemiesCount < totalEnemies)
        {
            for (int i = 0; i < enemiesPerWave && spawnedEnemiesCount < totalEnemies; i++)
            {
                var enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                var health = enemy.GetComponent<Health>();
                health.OnDeath += () => HandleEnemyDeath(enemy);
                spawnedEnemiesCount++;
            }
            if(spawnedEnemiesCount < totalEnemies) {
                yield return new WaitUntil(() => spawnedEnemiesCount == destroyedEnemiesCount);
            }
        }
    }

    private void HandleEnemyDeath(GameObject enemy) {
        Destroy(enemy);
        EnemyDestroyed();
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Generate random X and Z positions within the specified bounds
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Return the random position
        return new Vector3(randomX, randomY, 0);
    }

    public void EnemyDestroyed()
    {
        destroyedEnemiesCount++;
        if (destroyedEnemiesCount >= totalEnemies)
        {
            boss.SetActive(true); // Activate the boss when all enemies are destroyed
        }
    }
}
