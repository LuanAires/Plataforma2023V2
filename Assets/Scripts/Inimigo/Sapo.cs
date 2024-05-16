using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
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
    }

    private void Update()
    {
        if (Vector3.Distance(Heroi.transform.position, transform.position) < 5)
        {

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
        Animador.SetTrigger("Dano");
        
        // Verifica se o inimigo está morto
            
    }
}
