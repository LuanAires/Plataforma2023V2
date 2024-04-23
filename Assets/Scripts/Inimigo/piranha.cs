using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piranha : MonoBehaviour
{
    public int hp = 10;
    public GameObject Heroi;
    public Animator Animador;
    

    private int hpMax;

    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(Heroi.transform.position, transform.position) < 5)
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            AplicarDano(1);
        }
    }
    public void Morrer()
    {
        
        Destroy(gameObject);
    }
    

    public void AplicarDano(int dano)
    {
        hp -= dano;

        // Verifica se o inimigo está morto
        if (hp <= 0)
        {
            Morrer();
        }
    }


}
