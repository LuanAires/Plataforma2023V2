using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hp = 1;
    public GameObject Espada;
    public GameObject Heroi;
    public Animator Animador;
    public GameObject dropPrefab;

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
        
        DroparAlma();
        Destroy(gameObject);
    }
    void DroparAlma()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
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
