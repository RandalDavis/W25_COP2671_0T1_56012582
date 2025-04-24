using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    GameOver,
    Paused
}

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    public GameState CurrentState { get; private set; } = GameState.Playing;

    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerGameOver()
    {
        if (CurrentState == GameState.GameOver) return;

        CurrentState = GameState.GameOver;
        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSecondsRealtime(1f); // Wait 1 second regardless of Time.timeScale

        Time.timeScale = 0f;

        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PauseMusic();
        }

        FindFirstObjectByType<GameTimer>().StopTimer(); //stops timer
        FindFirstObjectByType<ScoreManager>().ShowFinalScores(); //shows final scores
        gameOverPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        Debug.Log("Open settings menu..."); //build this later
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        CurrentState = GameState.Playing;

        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.RestartMusic();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

