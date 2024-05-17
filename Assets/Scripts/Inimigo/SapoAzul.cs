using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoAzul : MonoBehaviour
{
    public int hp = 1;
    public GameObject Heroi;
    public Animator Animador;
    public GameObject dropPrefab;
    private HpBarraInimigo hpini;

    private int hpMax;

    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponentInChildren<Animator>();

        // Encontrar a barra de HP do inimigo no mesmo GameObject ou atribuí-la manualmente
        hpini = GetComponentInChildren<HpBarraInimigo>();

        if (hpini != null)
        {
            hpini.maxlife = hpMax;
            hpini.currentylife = hp;
        }
    
    }

    private void Update()
    {
        if (Vector3.Distance(Heroi.transform.position, transform.position) < 5)
        {
            // Lógica para quando o herói está perto do sapo
        }

        if (hp <= 0)
        {
            Morrer();
        }
    }

    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            AplicarDano(10);
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



        // Atualizar a barra de HP do inimigo
        if (hpini != null)
        {
            hpini.currentylife = hp;
        }
    }

}
