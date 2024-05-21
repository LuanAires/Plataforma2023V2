using System.Security.Cryptography;
using UnityEngine;

public class Espirito : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float velocidade = 1.0f; 
    public GameObject fantasma;
    public Transform pontoOrigem;
    public float distanciaDeAtaque = 2.0f; 
    public int danoDoAtaque = 10; 
    public int hp =500; 
    public int hpMax;
    public Animator Animador;
    public GameObject Heroi;
    private Vector3 posicaoInicial; 
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
        
        posicaoInicial = transform.position;
        Heroi = FindObjectOfType<GameObject>();
    }

    private void Update()
    {

        if (hp <= 0)
        {
            Morrer();
        }

        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);   
        float distanciaAoJogador = Vector3.Distance(transform.position, Heroi.transform.position);
        if (distanciaAoJogador < distanciaDeAtaque)
        {
            if (Animador != null)
            {
                Animador.SetTrigger("Atacar");
            }
        }
    }
    public void Disparo()
    {
        GameObject Tiro = Instantiate(fantasma, pontoOrigem.transform.position, Quaternion.identity);
        Destroy(Tiro, 3f);

        if (transform.localScale.x == -1)
        {
            Tiro.GetComponent<AtaqueDistancia>().MudaVelocidade(-5);
        }
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
    private void Morrer()
    {
       
        if (Animador != null)
        {
            Animador.SetTrigger("Morrer");
        }
        if (hp <=0) 
        {
            Animador.SetBool("Morrer", true);

        }
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            AplicarDano(1);
        }
    }

}