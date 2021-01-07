using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VaccinePickup : MonoBehaviour
{
    public GameObject vaccinePanel;

    private void OnTriggerEnter2D(Collider2D player)
    {

        if (player.tag == "Player" && GameManager.instance.getKnowledge() == GameManager.instance.maxKnowledge)
        {
            if (vaccinePanel != null)
            {
                vaccinePanel.SetActive(false);
            }
            Destroy(gameObject);
        } 
        else if(player.tag == "Player" && GameManager.instance.getKnowledge() != GameManager.instance.maxKnowledge)
        {
            Debug.Log("NOT ENOUGH KNOWLEDGE!");
        }
    }
}
