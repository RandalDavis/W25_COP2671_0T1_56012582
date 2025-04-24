using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public float spawnInterval = 4f;

    private float timer = 0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBomb();
            timer = 0f;
        }
    }

    void SpawnBomb()
    {
        // Bottom of seagull range: about 60% screen height
        float lowestSeagullY = cam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;

        // Bomb spawns a bit below that
        float spawnY = lowestSeagullY - 1f;

        // Random X position across the screen
        float minX = cam.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float maxX = cam.ViewportToWorldPoint(new Vector2(1, 0)).x;
        float spawnX = Random.Range(minX, maxX);

        Vector2 spawnPos = new Vector2(spawnX, spawnY);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }
}