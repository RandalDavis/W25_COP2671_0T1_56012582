using UnityEngine;

public class BeachballPopper : MonoBehaviour
{
    private Vector3 startPosition;
    public float maxTravelDistance = 30f;
    public AudioClip popSound; // Assign your pop sound in the inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Seagull"))
        {
            PopBeachball();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seagull"))
        {
            PopBeachball();
        }
    }

    void PopBeachball()
    {
        // Play pop sound at beachball’s position
        AudioSource.PlayClipAtPoint(popSound, transform.position);

        //Pop up the game over screen
        FindFirstObjectByType<GameOverManager>().ShowGameOver();

        // Destroy the beachball
        Destroy(gameObject);
    }

}