using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        Gilmar player = other.GetComponent<Gilmar>();
        if (player != null)
        {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}

