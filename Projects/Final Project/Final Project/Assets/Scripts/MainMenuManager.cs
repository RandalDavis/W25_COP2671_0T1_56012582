using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Prototype 5"); // Replace with your actual game scene name
    }

    public void OpenOptions()
    {
        Debug.Log("Options menu coming soon...");
        // You can later open a UI panel with settings here
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}