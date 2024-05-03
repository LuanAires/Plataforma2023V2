using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espirito : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude do movimento de flutuação
    public float velocidade = 1.0f; // Velocidade do movimento de flutuação
    public float distanciaDeAtaque = 2.0f; // Distância de ataque do inimigo
    public int danoDoAtaque = 10; // Dano causado pelo ataque do inimigo
    public GameObject jogador; // Referência ao GameObject do jogador
    public Animator animador; // Referência ao Animator do inimigo

    private Vector3 posicaoInicial; // Posição inicial do inimigo

    private void Start()
    {
        posicaoInicial = transform.position; // Salva a posição inicial do inimigo
        jogador = GameObject.FindGameObjectWithTag("Player"); // Encontra o GameObject do jogador
    }

    private void Update()
    {
        // Calcula a posição vertical usando a função seno para criar um movimento de flutuação
        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;

        // Atualiza a posição do inimigo com a posição inicial e o movimento vertical
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);

        // Verifica a distância entre o inimigo e o jogador
        float distanciaAoJogador = Vector3.Distance(transform.position, jogador.transform.position);
        if (distanciaAoJogador < distanciaDeAtaque)
        {
            // Se o jogador estiver perto o suficiente, executa a animação de ataque (se houver)
            if (animador != null)
            {
                animador.SetTrigger("Atacar");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Personagem personagem = collision.gameObject.GetComponent<Personagem>();
            personagem.PerderHp(danoDoAtaque);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        { 
            Personagem personagem = collision.gameObject.GetComponent<Personagem>();
            personagem.PerderHp(danoDoAtaque);
        }
    }

}



