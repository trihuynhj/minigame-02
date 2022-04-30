using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) { Resume(); }
            else { Pause(); }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Menu()
    {
        Debug.Log("MENU");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Restart()
    {
        Debug.Log("RESTART");
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Scenes/Default");
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public bool CheckGamePause()
    {
        if (gameIsPaused) { return true; }
        else { return false; }
    }
}
