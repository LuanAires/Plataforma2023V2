using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gilmar : MonoBehaviour
{

    private Rigidbody2D Corpo;
    [SerializeField] private Animator Animador;
    [SerializeField] float velocidade;
    [SerializeField] private float jumpForce = 350f;
    [SerializeField] LayerMask segredoLayer;
    //barra de informação//
    private HpBarraGilmar barra;
    public int maxLife = 100;
    public int currentylife;
    public int maxMana = 100;
    public int currentyMana;
    public int qtd_pulos = 2;
    public float velExtra = 0;
    public AudioSource audio;
    private bool isPlaying = false;

    //Ataque Distancia\\
    public float meuTempoTiro = 0;
    public GameObject MeuAtkD;
    public GameObject PontoDeOrigem;
    public bool pode_atirar = true;
    public AtaqueEspecial especial;

    //Ataque Perto\\
    public GameObject CaixaCorreio;
    public GameObject Alma;

    //Quantidade de Sangue\\
    public int hp = 100;
    public int perderHp;
    private Vector3 originalScale;
    float hAxis, vAxis, velX, velY;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + 3), 1);
        
    }

    void Start()
    {
        
        Corpo = GetComponent<Rigidbody2D>();
        Animador = GetComponentInChildren<Animator>();
        barra = GetComponentInChildren<HpBarraGilmar>();

    }
    void Update()
    {
        currentylife = hp;
        if (hp > 0)
        {
            Mover();
            AtaqueDistancia();
            AtivarEspecial();

        }
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
        {
            audio.Play();
            isPlaying = true;
            Pular();
        }
    }
    #region ataque
    void AtaqueDistancia()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isPlaying )
        {
            audio.Play();
            isPlaying = true;
            Disparo();
            Animador.SetTrigger("Disparo");
            
        }
    }
    public void UsarMana(int quantidade)
    {
        currentyMana -= quantidade;
        if (currentyMana < 0) currentyMana = 0;
        
    }
    public void RecuperarMana(int quantidade)
    {
        currentyMana += quantidade;
        if (currentyMana > maxMana) currentyMana = maxMana;
       
    }
    public void RecuperarVida(int quantidade)
    {
        currentylife += quantidade;
        if (currentylife > maxLife) currentylife = maxLife;
        
    }
    public void Disparo()
    {
        Vector3 pontoDeOrigem = PontoDeOrigem.transform.position;
        GameObject CartaJogada= Instantiate(MeuAtkD, pontoDeOrigem, Quaternion.identity);

        if (transform.localScale.x == -1)
        {
            CartaJogada.GetComponent<BulletControl>().DiracaoBala(-0.08f);
        }
        else 
        {
            CartaJogada.GetComponent<BulletControl>().DiracaoBala(0.08f);
        }

        Destroy(CartaJogada, 1f);
    }
    private void AtivarEspecial()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPlaying)
        {
            audio.Play();
            isPlaying = true;

            currentyMana--;            
            Animador.SetTrigger("AttackSpecial");
        }
    }
    #endregion

    private void FixedUpdate()
    {
        velX = hAxis * Time.fixedDeltaTime * (velocidade + velExtra);
        velY = Corpo.velocity.y;

        Corpo.velocity = new Vector2(velX, velY);
    }
    void Mover()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");


        RaycastHit2D hitDown = Physics2D.CircleCast(transform.position, 1, Vector2.down, 0, segredoLayer);

        RaycastHit2D hitUp = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y + 3), 1, Vector2.up, 0, segredoLayer);

        if (hitDown) 
        {
            if (vAxis < 0 && qtd_pulos < 2) 
            {
                Collider2D plataformaCollider = hitDown.collider;
                StartCoroutine("TriggerPlataformaSecreta",plataformaCollider);
            }
        }

        if(hitUp) 
        {
            Collider2D plataformaCollider = hitUp.collider;
            StartCoroutine("TriggerPlataformaSecreta", plataformaCollider);
        }

        if (velX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Animador.SetBool("Correndo", true);
        }
        else if (velX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Animador.SetBool("Correndo", true);
        }
        else
        {
            Animador.SetBool("Correndo", false);
        }
    }
    void Pular()
    {
        if (qtd_pulos > 0)
        {            
            Corpo.AddForce(Vector3.up * jumpForce);
            Animador.SetBool("Jump", true);
        }
        qtd_pulos--;
    }
    private void OnTriggerEnter2D(Collider2D tocou)
    {
        if (tocou.gameObject.tag == "Solo")
        {
            qtd_pulos = 2;
            jumpForce = 500;
            Animador.SetBool("Jump", false);
        }
        if (tocou.gameObject.tag == "Atk_inimigo")
        {
            AtkInimigoController atkInimigo = tocou.GetComponent<AtkInimigoController>();
            if (atkInimigo)
            {
                int dano = atkInimigo.Dano;
                hp -= dano;
                Animador.SetTrigger("Dano");
            }
            else 
            {
                Debug.LogWarning("Ataque sem AtkInimigoController");
            }
        }
        else 
        {
           Animador.SetBool("Dano", false);
        }
        if (tocou.tag == "Morte")
        {
            PerderHp(10);
            SceneManager.LoadScene(4);
        }
        if (tocou.CompareTag("Player"))
        {
            CollectItem();
        }

    }
    private void CollectItem()
    {       
        Destroy(gameObject);
    }
    public void Dano()
    {
        hp--;
        if (hp <= 0)
        {
            Animador.SetBool("Morreu", true);
        }
    }
    public void PerderHp(int quantidade)
    {
        if (hp > 0)
        {
            hp -= quantidade; 
            if (hp <= 0)
            {
              Morrer();
            }
        }
    }
    public void Morrer()
    {
        Destroy(this.gameObject);
    }
    IEnumerator TriggerPlataformaSecreta(Collider2D colliderPlataforma) 
    {
        colliderPlataforma.isTrigger= true;
        yield return new WaitForSeconds(0.5f);
        colliderPlataforma.isTrigger = false;
    }
    internal void heal(int healAmount)
    {
        throw new NotImplementedException();
    }
}