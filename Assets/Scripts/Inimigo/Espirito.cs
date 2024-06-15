using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Espirito : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float velocidade = 1.0f; 
    public Transform pontoOrigem;
    public GameObject projetilPrefab;
    public float distanciaDeAtaque = 2.0f; 
    public int danoDoAtaque = 10; 

    public int hp =500; 
    public int hpMax;
    private HpBarraInimigo hpbarr;
    public Animator Animador;
    public GameObject Heroi;
    private Vector3 posicaoInicial; 

    public GameObject dropPrefab;
    public float velocidadeProjetil = 5f;
    private bool heroiDentroRaio = false;
    private float maxcooldown = 2;
    private float contadortiro;
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
                StartCoroutine(LançarProjetil());
                contadortiro = 0;
            }

            if (contadortiro <= maxcooldown)
            {
                contadortiro += Time.deltaTime;
            }
        }

        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);   
        float distanciaAoJogador = Vector3.Distance(transform.position, Heroi.transform.position);
        if (distanciaAoJogador < distanciaDeAtaque)
        {
            if (Animador != null)
            {
                Animador.SetTrigger("Cuspe");
            }
        }
    }
    
    public void MeuTiro()
    {
        if (projetilPrefab != null)
        {
            GameObject projetil = Instantiate(projetilPrefab, pontoOrigem.position, Quaternion.identity);

            Vector2 direcao = (Heroi.transform.position - transform.position).normalized;

            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direcao * velocidadeProjetil;
            }
            Destroy(projetil, 2f);
        }
    }
    private IEnumerator LançarProjetil()
    {
        Animador.SetTrigger("Cuspe");
        //MeuTiro();
        Invoke("MeuTiro", 0.9f);
        yield return new WaitForSeconds(Animador.GetCurrentAnimatorStateInfo(0).length);
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
        if (hp <=0) 
        {
            Animador.SetBool("Morrer", true);

        }
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Player") 
        {
            heroiDentroRaio = true;
        }
        if (tocar.gameObject.tag == "Atk")
        {
            AplicarDano(10);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            heroiDentroRaio = false;
        }
    }
}