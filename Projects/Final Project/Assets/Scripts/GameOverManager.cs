using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // pause the game

        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PauseMusic();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.RestartMusic();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettings()
    {
        Debug.Log("Open settings menu..."); // You can build this later
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}