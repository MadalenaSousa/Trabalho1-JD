using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Soundtrack") != null)
        {
            GameObject.FindGameObjectWithTag("Soundtrack").GetComponent<Music>().PlayMusic();
        }
    }
    public void backToInitialMenu()
    {
        SceneManager.LoadScene("InitialMenu");
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
}
