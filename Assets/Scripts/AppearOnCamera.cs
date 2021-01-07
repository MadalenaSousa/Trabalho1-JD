using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnCamera : MonoBehaviour
{
    public GameObject toiletPanel, coronaPanel, knowledgePanel, protesterPanel, vaccinePanel;
    public Renderer toiletPaper, corona, knowledge, protesters, vaccine;

    private void Start()
    {
        toiletPanel.SetActive(false);
        coronaPanel.SetActive(false);
        knowledgePanel.SetActive(false);
        protesterPanel.SetActive(false);
        vaccinePanel.SetActive(false);
    }

    private void Update()
    {
        if(toiletPaper != null)
        {
            if (toiletPaper.isVisible)
            {
                toiletPanel.SetActive(true);
                coronaPanel.SetActive(false);
                knowledgePanel.SetActive(false);
                protesterPanel.SetActive(false);
                vaccinePanel.SetActive(false);
            }
            else
            {
                toiletPanel.SetActive(false);
            }
        }

        if (corona != null)
        {
            if (corona.isVisible)
            {
                coronaPanel.SetActive(true);
                toiletPanel.SetActive(false);
                knowledgePanel.SetActive(false);
                protesterPanel.SetActive(false);
                vaccinePanel.SetActive(false);
            }
            else
            {
                coronaPanel.SetActive(false);
            }
        }

        if (knowledge != null)
        {
            if (knowledge.isVisible)
            {
                knowledgePanel.SetActive(true);
                toiletPanel.SetActive(false);
                coronaPanel.SetActive(false);
                protesterPanel.SetActive(false);
                vaccinePanel.SetActive(false);
            }
            else
            {
                knowledgePanel.SetActive(false);
            }
        }

        if (protesters != null)
        {
            if (protesters.isVisible)
            {
                protesterPanel.SetActive(true);
                toiletPanel.SetActive(false);
                coronaPanel.SetActive(false);
                knowledgePanel.SetActive(false);
                vaccinePanel.SetActive(false);
            }
            else
            {
                protesterPanel.SetActive(false);
            }
        }

        if (vaccine != null)
        {
            if (vaccine.isVisible)
            {
                vaccinePanel.SetActive(true);
                protesterPanel.SetActive(false);
                toiletPanel.SetActive(false);
                coronaPanel.SetActive(false);
                knowledgePanel.SetActive(false);
            }
            else
            {
                vaccinePanel.SetActive(false);
            }
        }
    }
}
