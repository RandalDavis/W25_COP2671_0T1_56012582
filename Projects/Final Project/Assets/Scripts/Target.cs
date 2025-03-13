using UnityEngine;
using UnityEngine.Rendering;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float xRange = 5;
    private float ySpawnPos = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
