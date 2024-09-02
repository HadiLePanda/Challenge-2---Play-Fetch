using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] ballPrefabs;

    [Header("Settings")]
    [SerializeField] private float startDelay = 1f;
    [SerializeField] private float spawnIntervalMin = 3f;
    [SerializeField] private float spawnIntervalMax = 5f;
    [SerializeField] private float spawnLimitXLeft = -22f;
    [SerializeField] private float spawnLimitXRight = 7f;
    [SerializeField] private float spawnPosY = 30f;

    private float lastSpawnTime;
    private float nextSpawnInterval;
    private bool canSpawn = false;

    private void Start()
    {
        // initialize spawn timer values
        UpdateTimerValues();

        // trigger spawning logic after delay
        Invoke(nameof(EnableSpawning), startDelay);
    }

    public void EnableSpawning() => canSpawn = true;
    public void DisableSpawning() => canSpawn = false;

    private void Update()
    {
        // wait for initial spawn trigger
        if (!canSpawn)
            return;

        // spawn a ball at random time intervals
        if (Time.time >= lastSpawnTime + nextSpawnInterval)
        {
            SpawnRandomBall();
            UpdateTimerValues();
        }
    }

    private void UpdateTimerValues()
    {
        // update last spawn timestamp and randomly choose next spawn time
        lastSpawnTime = Time.time;
        nextSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    // spawn random ball at random x position at top of play area
    private void SpawnRandomBall()
    {
        // generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
