using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    private void Start() 
    { 
        if(GameObject.FindGameObjectWithTag("Soundtrack") != null)
        {
            GameObject.FindGameObjectWithTag("Soundtrack").GetComponent<Music>().PlayMusic();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        SceneManager.LoadScene("InitialMenu");
    }
}
