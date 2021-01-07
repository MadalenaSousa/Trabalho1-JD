using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgePickup : MonoBehaviour
{
    public int KnowledgeValue = 1;
    public GameObject knowledgePanel;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.tag == "Player")
        {
            GameManager.instance.knowledgeSound.Play();
            GameManager.instance.IncreaseKnowledge(KnowledgeValue);
            if (knowledgePanel != null)
            {
                knowledgePanel.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
