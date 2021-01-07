using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 lastCheckpoitPos;
    
    public Text toiletPaperCountText;
    int score;
    
    public VaccineBar knowledgeBar;
    public int currentKnowledge = 0;
    public int maxKnowledge = 100;

    float currentTime = 0f;
    float startTimeSec = 270f;
    public Text countdownText;

    public GameObject isolationMenu;
    float isolationStart;
    public bool isIsolated;

    public AudioSource toiletPaperSound;
    public AudioSource knowledgeSound;
    public AudioSource dieSound;
    public AudioSource winSound;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Soundtrack") != null)
        {
            GameObject.FindGameObjectWithTag("Soundtrack").GetComponent<Music>().PlayMusic();
        }

        if (instance == null)
        {
            instance = this;
        }

        knowledgeBar.setKnowledge(currentKnowledge);
        knowledgeBar.setMaxKnowledge(maxKnowledge);

        currentTime = startTimeSec;
        countdownText.text = (Mathf.Floor(currentTime / 60)).ToString("00") + ":" + Mathf.Floor(currentTime % 60).ToString("00");

        isolationMenu.SetActive(false);

        isIsolated = false;
    }

    private void Update()
    {
        //TIMER
        currentTime -= Time.deltaTime;
        countdownText.text = (Mathf.Floor(currentTime/60)).ToString("00") + ":" + Mathf.Floor(currentTime % 60).ToString("00");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }

        //LOSE CONDITION
        if(currentTime <= 0 && knowledgeBar.getKnowledge() != maxKnowledge)
        {
            SceneManager.LoadScene("YouLose");
        }

        //ISOLATION
        if(PlayerControl.instance.getHealth() == 0 && isIsolated == false)
        {
            isolationStart = currentTime;
            PlayerControl.instance.transform.position = GameManager.instance.lastCheckpoitPos;
            isIsolated = true;
            PlayerControl.instance.isMoving = false;
            isolationMenu.SetActive(true);
        }

        if (isIsolated == true && Mathf.Abs(currentTime - isolationStart) >= 8f)
        {
            isIsolated = false;
            PlayerControl.instance.setHealth(100);
            PlayerControl.instance.isMoving = true;
            isolationMenu.SetActive(false);
        }
    }

    public void ChangeScore(int TPValue) //Toilet paper control
    {
        score += TPValue;
        toiletPaperCountText.text = "x" + score.ToString("");
    }

    //Knowledge Control
    public void IncreaseKnowledge(int KnowledgeValue)
    {
        currentKnowledge += KnowledgeValue;
        knowledgeBar.setKnowledge(currentKnowledge);
    }

    public int getKnowledge()
    {
        return currentKnowledge;
    }
}
