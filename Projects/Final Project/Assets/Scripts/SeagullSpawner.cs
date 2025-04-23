using UnityEngine;

public class SeagullSpawner : MonoBehaviour
{
    public GameObject seagullPrefab;      // Assign the seagull prefab in the inspector
    public float spawnInterval = 2f;      // Time between spawns
    public float minSpeed = 1f;           // Min speed for seagull
    public float maxSpeed = 3f;           // Max speed for seagull
    public AudioClip squawkSound;         // Assign a squawk sound in the inspector

    private Camera mainCam;
    private float timer;
    private int seagullCount = 0;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Debug.Log("Spawning seagull...");
            SpawnSeagull();
            timer = 0f;
        }

        // Optional: Destroy this spawner if it goes offscreen (might not apply here)
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1.1f, 0)).x)
        {
            Destroy(gameObject);
        }
    }

    void SpawnSeagull()
    {
        float screenHeight = mainCam.orthographicSize * 2f;
        float topYMin = mainCam.ViewportToWorldPoint(new Vector2(0, 0)).y + screenHeight * 0.6f;
        float topYMax = mainCam.ViewportToWorldPoint(new Vector2(0, 1)).y;

        float randomY = Random.Range(topYMin, topYMax);

        // Randomly choose left or right side
        bool fromLeft = Random.value < 0.5f;

        float spawnX = fromLeft
            ? mainCam.ViewportToWorldPoint(new Vector2(0, 0)).x - 1f
            : mainCam.ViewportToWorldPoint(new Vector2(1, 0)).x + 1f;

        Vector2 spawnPos = new Vector2(spawnX, randomY);
        GameObject seagull = Instantiate(seagullPrefab, spawnPos, Quaternion.identity);

        // Set direction and velocity
        float direction = fromLeft ? 1f : -1f;
        float speed = Random.Range(minSpeed, maxSpeed);
        seagull.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed * direction, 0);

        // Flip sprite if needed
        Vector3 scale = seagull.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        seagull.transform.localScale = scale;

        // Track how many have spawned
        seagullCount++;

        // Play squawk sound every 4th spawn
        if (seagullCount % 4 == 0 && squawkSound != null)
        {
            AudioSource.PlayClipAtPoint(squawkSound, spawnPos);
        }
    }

    float screenLeftOutside()
    {
        Vector2 leftEdge = mainCam.ViewportToWorldPoint(new Vector2(0, 0.5f));
        return leftEdge.x - 1f;
    }
}