using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Gilmar>();
        if (player != null)
        {
           
        }
    }
}
