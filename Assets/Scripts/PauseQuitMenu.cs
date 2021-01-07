using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseQuitMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseQuitMenuUI;

    private void Start()
    {
        pauseQuitMenuUI.SetActive(false);
    }

    public void Resume()
    {
        pauseQuitMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseQuitMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("InitialMenu");
        Time.timeScale = 1f;
    }
}
