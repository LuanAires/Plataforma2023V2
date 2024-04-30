using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CabecaBoss : MonoBehaviour
{
    public int hp = 1;
    private int hpMax;
    public int danoEspada = 1;
    public int danoCuspe = 1;
    public int danoAvanco = 1;
    public int danoCartola = 1;
    public float velocidadeAvanco = 5f;
    public GameObject Espada;
    public GameObject Heroi;
    public Animator Animador;
    public GameObject dropPrefab;
    public GameObject CartolaPrefab;

    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponent<Animator>();
    }

    private void Update()
    {
                   
         
    }

    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            AplicarDano(danoEspada);
        }
    }

    void Cuspir()
    {
        
    }

    void Avancar()
    {
        
    }

    void LancarCartola()
    {
        
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

        if (hp <= 0)
        {
            Morrer();
        }
    }
}
