using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private GameObject pillarPrefab; // Drag your Pillar prefab here
    [SerializeField] private float spawnRate = 2.0f;    // Time in seconds between spawns

    [Header("Height Variation Settings")]
    [SerializeField] private float heightOffset = 2.5f; // How much the pillar can move up or down

    private float timer = 0f;

    void Start()
    {
        // Spawn the first pillar immediately when the game starts
        SpawnPillar();
    }

    void Update()
    {
        // Don't spawn anything if the game is over
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        // Keep track of time passing
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPillar();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnPillar()
    {
        // Calculate the lowest and highest possible Y points
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Pick a random height between those positions
        float randomHeight = Random.Range(lowestPoint, highestPoint);

        // Define the exact spawn position (using the spawner's X, but the randomized Y)
        Vector3 spawnPosition = new Vector3(transform.position.x, randomHeight, 0);

        // Instantiate (create) the new pillar clone into the scene
        Instantiate(pillarPrefab, spawnPosition, transform.rotation);
    }
}