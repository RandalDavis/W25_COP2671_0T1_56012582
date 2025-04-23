using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AudioClip explosionSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Explode(other.gameObject);
        }
    }

    void Explode(GameObject player)
    {
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        FindFirstObjectByType<GameOverManager>().ShowGameOver();

        Destroy(player);     // destroy beachball
        Destroy(gameObject); // destroy bomb
    }
}