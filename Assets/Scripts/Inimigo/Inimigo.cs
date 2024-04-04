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
            // Verificar se o jogador est� dentro do alcance de ataque
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
            // Se o jogador n�o estiver por perto, patrulhe a �rea
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

        // Verifica se o inimigo est� morto
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
        // Coloque aqui o c�digo para atacar o jogador
        Debug.Log("Atacando o jogador!");
    }

    private void Patrol()
    {
        // Mover para o pr�ximo ponto de patrulha
        if (patrolPoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].position, moveSpeed * Time.deltaTime);

            // Verificar se chegou ao ponto de patrulha
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position) < 0.1f)
            {
                // Avan�ar para o pr�ximo ponto de patrulha
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            }
        }

    }
}
