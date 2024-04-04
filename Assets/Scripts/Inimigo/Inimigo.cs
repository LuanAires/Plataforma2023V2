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
    public float detectionRadius = 5f;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;
    public Transform[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    private Transform player;

    private int hpMax;

    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (Vector3.Distance(Heroi.transform.position, transform.position) < 5)
        {
            Animador.SetTrigger("Proximo");
        }
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Verificar se o jogador está dentro do alcance de ataque
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                // Ataque ao jogador
                AttackPlayer();
            }
            else
            {
                // Seguir o jogador
                MoveTowardsPlayer();
            }
        }
        else
        {
            // Se o jogador não estiver por perto, patrulhe a área
            Patrol();
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
    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // Coloque aqui o código para atacar o jogador
        Debug.Log("Atacando o jogador!");
    }

    private void Patrol()
    {
        // Mover para o próximo ponto de patrulha
        if (patrolPoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].position, moveSpeed * Time.deltaTime);

            // Verificar se chegou ao ponto de patrulha
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position) < 0.1f)
            {
                // Avançar para o próximo ponto de patrulha
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            }
        }

    }
}
