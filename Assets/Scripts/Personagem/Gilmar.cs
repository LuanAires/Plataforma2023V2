using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gilmar : MonoBehaviour
{

    private Rigidbody2D Corpo;
    [SerializeField] private Animator Animador;
    [SerializeField] float velocidade;
    [SerializeField] private float jumpForce = 350f;
    [SerializeField] LayerMask segredoLayer;

    public int qtd_pulos = 2;
    public float velExtra = 0;

    bool pode_dano;
    //Ataque Distancia
    public float meuTempoTiro = 0;
    public GameObject MeuAtkD;
    public GameObject PontoDeOrigem;
    public bool pode_atirar = true;
    //Ataque Perto
    public GameObject CaixaCorreio;
    public GameObject Alma;
    //Quantidade de Sangue
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
    }
    void Update()
    {
        if (hp > 0)
        {
            Mover();
            //  originalScale = transform.localScale;
            AtaqueDistancia();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pular();
        }
    }
    #region ataque
    void AtaqueDistancia()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Disparo();
            Animador.SetBool("Disparo", true);
        }

       if (Input.GetKeyUp(KeyCode.K))
        {
            Disparo();
            Animador.SetBool("Disparo", false);
        }
    }
    public void Disparo()
    {
        Vector3 PontoDeOrigem = new Vector3(transform.position.x + 0.3f, transform.position.z);
        GameObject CartaJogada= Instantiate(MeuAtkD, PontoDeOrigem, Quaternion.identity);
        CartaJogada.GetComponent<BulletControl>().DiracaoBala(0.08f);
        Destroy(MeuAtkD, 1f);

        /*if (transform.localScale.x == -1)
        {
            Carta.GetComponent<AtaqueDistancia>().MudaVelocidade(5);
        }*/
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
           
        }
        if (tocou.tag == "Morte")
        {
            PerderHp(1);
            SceneManager.LoadScene(3);
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
            else
            {
                if (Animador != null)
                {
                    //Animador.SetBoll("Dano");
                }
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
}
    
