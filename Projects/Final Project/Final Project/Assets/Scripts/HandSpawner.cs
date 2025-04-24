using UnityEngine;

public class HandSpawner : MonoBehaviour
{

    public GameObject handPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Spawing Hands...");
        SpawnHand(new Vector2(-5, 1));
        SpawnHand(new Vector2(5, 1));
    }

    void SpawnHand(Vector2 position)
    {
        Instantiate(handPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
