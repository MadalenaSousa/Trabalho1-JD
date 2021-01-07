using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsolationControl : MonoBehaviour
{
    float currentIsolationTime = 0f;
    float startIsolationTime = 5f;
    //public Text isolationTimeText;
    public GameObject isolationMenu;

    void Start()
    {
        currentIsolationTime = startIsolationTime;
    }

    void Update()
    {
        currentIsolationTime -= Time.deltaTime;

        /*if(currentIsolationTime <= 0)
        {
            isolationMenu.SetActive(false);
        }*/
    }
}
