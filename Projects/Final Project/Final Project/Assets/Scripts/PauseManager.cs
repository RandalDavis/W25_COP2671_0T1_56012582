using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameTimer timerText; // Reference to your timer script
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        FindFirstObjectByType<MusicManager>().PauseMusic();
        pauseMenuUI.SetActive(true);

        if (timerText != null)
            timerText.PauseTimer();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false);

        if (timerText != null)
            timerText.ResumeTimer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        // Add options panel toggle here later
        Debug.Log("Options clicked.");
    }
}
