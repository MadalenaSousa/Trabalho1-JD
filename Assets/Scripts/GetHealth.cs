using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour
{
    public void restoreHealth()
    {
        int fullHealth = PlayerControl.instance.maxHealth;
        PlayerControl.instance.setHealth(fullHealth);
    }
}
