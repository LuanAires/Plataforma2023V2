using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoAzul : MonoBehaviour
{
    public Transform pontoOrigem;
    public int hp = 1;
    public GameObject Gilmar;
    public Animator Animador;
    public GameObject dropPrefab;
    public GameObject projetilPrefab;
    public float velocidadeProjetil = 5f;
    private HpBarraInimigo hpini;

    private float maxcooldown = 2;
    private float contadortiro;

    private int hpMax;
    private bool heroiDentroRaio = false;

    private void Start()
    {
        hpMax = hp;
        Gilmar = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponentInChildren<Animator>();
        hpini = GetComponentInChildren<HpBarraInimigo>();

        if (hpini != null)
        {
            hpini.maxlife = hpMax;
            hpini.currentylife = hp;
        }
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Morrer();
        }
        else
        {
            if (heroiDentroRaio && contadortiro >= maxcooldown)
            {
                LançarProjetil();
                contadortiro = 0;
            }

            if (contadortiro <= maxcooldown)
            {
                contadortiro += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Atk")
        {
            AplicarDano(10);
        }
        else if (other.gameObject.tag == "Player")
        {
            heroiDentroRaio = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            heroiDentroRaio = false;
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
        if (hp < 0) hp = 0;

        Animador.SetTrigger("Dano");

        if (hpini != null)
        {
            hpini.currentylife = hp;
        }
    }

    private void LançarProjetil()
    {
        if (projetilPrefab != null)
        {
            Animador.SetTrigger("Cuspe");

            GameObject projetil = Instantiate(projetilPrefab, pontoOrigem.position, Quaternion.identity);

            Vector2 direcao = (Gilmar.transform.position - transform.position).normalized;

            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direcao * velocidadeProjetil;
            }
            Destroy(projetil, 2f);
           
        }
    }
}
