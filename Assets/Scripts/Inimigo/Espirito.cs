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
    public int hp = 50; 
    public int hpMax;
    public Animator Animador; 
    Gilmar player;
    private Vector3 posicaoInicial; 
    private HpBarraInimigo hpini;


    private void Start()
    {
        hpini = GetComponentInChildren<HpBarraInimigo>();
        if (hpini != null)
        {
            hpini.maxlife = hpMax;
            hpini.currentylife = hp;
        }

        posicaoInicial = transform.position;
        player = FindObjectOfType<Gilmar>();
    }

    private void Update()
    {
        
        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;

        
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);

        
        float distanciaAoJogador = Vector3.Distance(transform.position, player.transform.position);
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

        if (hpini != null)
        {
            hpini.currentylife = hp;
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