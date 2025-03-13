using UnityEngine;

public class BeachballSpawner : MonoBehaviour
{
    public GameObject beachballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBeachball(new Vector2(0, 9.4f));
    }

    void SpawnBeachball(Vector3 position)
    {
        Instantiate(beachballPrefab, position, Quaternion.identity); // Instantiate the beachball at the specified position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
