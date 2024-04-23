using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piranha : MonoBehaviour
{

    public int hp = 10; // Pontos de vida da piranha
    public int dano = 1; // Dano causado pela piranha
    public GameObject heroi; // Referência ao GameObject do player
    public Animator animador; // Referência ao Animator da piranha

    private void Start()
    {
        heroi = GameObject.FindGameObjectWithTag("Player");
        animador = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifica se o jogador está próximo o suficiente
        if (Vector3.Distance(heroi.transform.position, transform.position) < 1.5f)
        {
            // Se estiver próximo, aplica dano
            AplicarDanoAoHeroi();
        }
    }

    private void AplicarDanoAoHeroi()
    {
        // Verifica se o player tem o script PerderVida anexado
        PerderVida perderVidaScript = heroi.GetComponent<PerderVida>();
        if (perderVidaScript != null)
        {
            // Chama a função PerderHp do script PerderVida
            perderVidaScript.PerderHp(dano);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Atk"))
        {
            // Se a piranha entrar em colisão com um objeto com a tag "Atk", aplica dano
            AplicarDano(dano);
        }
    }

    private void AplicarDano(int dano)
    {
        hp -= dano;

        // Verifica se a piranha está morta
        if (hp <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        // Executa a animação de morte, se houver
        if (animador != null)
        {
            animador.SetTrigger("Morrer");
        }
        // Aguarda um tempo para destruir o GameObject da piranha
        Destroy(gameObject, 0.5f);
    }
}

