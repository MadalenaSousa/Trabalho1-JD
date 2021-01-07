using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToilerPaperPickup : MonoBehaviour
{
    public int TPValue = 1;
    public GameObject toiletPanel;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.tag == "Player")
        {
            GameManager.instance.toiletPaperSound.Play();
            GameManager.instance.ChangeScore(TPValue);
            if(toiletPanel != null)
            {
                toiletPanel.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
