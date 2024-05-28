using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public int healAmount = 20;  // Quantidade de vida que o power-up restaura

    void OnTriggerEnter2D(Collider2D other)
    {
        Gilmar player = other.GetComponent<Gilmar>();
        if (player != null)
        {
            player.heal(healAmount);
            Destroy(gameObject);
        }
    }
}

