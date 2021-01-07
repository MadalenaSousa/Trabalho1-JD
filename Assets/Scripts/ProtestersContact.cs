using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtestersContact : MonoBehaviour
{
    public int healthValue = 1;
    private BoxCollider2D protesterCollider;
    public GameObject protesterPanel;

    private void Start()
    {
        protesterCollider = transform.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D info)
    {
        if (info.gameObject.tag == "Player")
        {
            if(!PlayerControl.instance.isDesinfecting)
            {
                Debug.Log("tocando");
                PlayerControl.instance.decreaseHealth(healthValue);
            } 
            else if(PlayerControl.instance.isDesinfecting)
            {
                if (protesterPanel != null)
                {
                    protesterPanel.SetActive(false);
                }
                Destroy(gameObject);
            }
        }
    }
}
