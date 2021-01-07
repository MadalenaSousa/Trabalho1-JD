using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Soundtrack") != null)
        {
            GameObject.FindGameObjectWithTag("Soundtrack").GetComponent<Music>().PlayMusic();
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
