using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaVirusPickup : MonoBehaviour
{
    public GameObject coronaPanel;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.tag == "Player")
        {
            GameManager.instance.dieSound.Play();
            PlayerControl.instance.CatchVirus();
            if (coronaPanel != null)
            {
                coronaPanel.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
