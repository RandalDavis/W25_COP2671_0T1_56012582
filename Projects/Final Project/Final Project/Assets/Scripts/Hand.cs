using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Beachball has tag "Player"
        {
            FindFirstObjectByType<ScoreManager>().AddPoint();
        }
    }
}
