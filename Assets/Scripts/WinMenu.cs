using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Soundtrack") != null)
        {
            GameObject.FindGameObjectWithTag("Soundtrack").GetComponent<Music>().PlayMusic();
        }
    }
    public void backToBegin()
    {
        SceneManager.LoadScene("InitialMenu");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
