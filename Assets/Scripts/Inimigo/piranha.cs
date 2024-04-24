using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piranha : MonoBehaviour
{

    public int hp = 10; // Pontos de vida da piranha
    public int dano = 1; // Dano causado pela piranha
    public Personagem player; // Refer�ncia ao GameObject do player
    public Animator animador; // Refer�ncia ao Animator da piranha

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        animador = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Se a piranha entrar em colis�o com um objeto com a tag "Atk", aplica dano
            player.PerderHp(dano);
        }
    }

    private void AplicarDano(int dano)
    {
        hp -= dano;

        // Verifica se a piranha est� morta
        if (hp <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        // Executa a anima��o de morte, se houver
        if (animador != null)
        {
            animador.SetTrigger("Morrer");
        }
        // Aguarda um tempo para destruir o GameObject da piranha
        Destroy(gameObject, 0.5f);
    }
}

