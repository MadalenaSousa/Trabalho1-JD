using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
    public AudioSource healthSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(healthSound != null)
            {
                healthSound.Play();
            }
            PlayerControl.instance.setHealth(PlayerControl.instance.maxHealth);
            Destroy(gameObject);
        }
    }
}
