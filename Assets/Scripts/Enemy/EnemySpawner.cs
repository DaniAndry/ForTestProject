using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyToSpawn;
    [SerializeField] private Player _target;

    private int _enemyCount = 3;
    private Vector2 _spawnXRange = new Vector2(-5f, 30f);
    private Vector2 _spawnYRange = new Vector2(-6f, 6f);

    private void Start()
    {
        SpawnRandomObjects();
    }

    private void SpawnRandomObjects()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            int randomObjectIndex = Random.Range(0, _enemyToSpawn.Length);
            Enemy enemyToSpawn = _enemyToSpawn[randomObjectIndex];

            float randomX = Random.Range(_spawnXRange.x, _spawnXRange.y);
            float randomY = Random.Range(_spawnYRange.x, _spawnYRange.y);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Enemy enemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            enemy.Init(_target);

        }
    }
}
