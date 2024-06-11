using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
    public Transform pontoOrigem;
    public GameObject Heroi;
    public Animator Animador;
    public int dropPrefefab = 10;
    public GameObject dropPrefab;
    private bool heroiDentroRaio = false;
    private float maxcooldown = 2;
    private float contadortiro;
    public int dano;
    public int hp = 1;
    private int hpMax;
    private HpBarraInimigo hpbarr;



    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponentInChildren<Animator>();
        hpbarr = GetComponentInChildren<HpBarraInimigo>();

        if (hpbarr != null)
        {
            hpbarr.maxlife = hpMax;
            hpbarr.currentylife = hp;
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
        Animador.SetBool("Morrendo", true);
        DroparAlma();
        Destroy(gameObject);
    }
    void DroparAlma()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
        dropPrefefab = 10;
    }
    public void AplicarDano(int dano)
    {
        hp -= dano;
        if (hp < 0) hp = 0;

        Animador.SetTrigger("Dano");

        if (hpbarr != null)
        {
            hpbarr.currentylife = hp;
        }
    }
}
