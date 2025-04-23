using UnityEngine;

public class SeagullDestroyOffscreen : MonoBehaviour
{
    private Vector3 startPosition;
    public float maxTravelDistance = 30f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }
}