using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
    public Transform pontoOrigem;
    public int hp = 1;
    public GameObject Player;
    public Animator Animador;
    public GameObject dropPrefab;
    public float velocidadeProjetil = 5f;
    private HpBarraInimigo hpini;

    private float maxcooldown = 2;
    private float contadortiro;

    private int hpMax;
    private bool heroiDentroRaio = false;

    // Novas variáveis para dano por área
    public int danoArea = 20;
    public float CubeDano = 5f;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
                
                contadortiro = 0;
            }
            if (contadortiro <= maxcooldown)
            {
                contadortiro += Time.deltaTime;
            }
            //VerificarHeroiDentroRaio();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Atk")
        {
            AplicarDano(10);
            print("colidiu");
        }
        if (other.gameObject.tag == "Player")
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

   /* private void VerificarHeroiDentroRaio()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, CubeDano);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                Gilmar player = hitCollider.gameObject.GetComponent<Gilmar>();
                if (player != null)
                {
                    Gilmar.AplicarDano(danoArea);

                }
            }
        }
    }*/

    public void Morrer()
    {
        Animador.SetBool("Morrendo", true);
        Destroy(gameObject);
    }
    public void AplicarDano(int dano)
    {
        hp -= dano;
        if (hp < 0) hp = 0;

        Animador.SetTrigger("Atk");

        if (hpini != null)
        {
            hpini.currentylife = hp;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, CubeDano);
    }
}
