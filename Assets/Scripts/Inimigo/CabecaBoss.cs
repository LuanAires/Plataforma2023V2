using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabecaBoss : MonoBehaviour
{
    public bool ativo = false;

    [SerializeField] Transform pontoOrigem;
    [SerializeField] Transform pontoDestino;

    [SerializeField] public SalaBoss gatilho;
    public int hp = 1;
    private int hpMax;
    public GameObject Cuspe;
    public GameObject PontoDeOrigem;
    public int danoCuspe = 9;
    public int danoAvanco = 13;
    public int danoCartola = 10;
    public float velocidadeAvanco = 5f;

    public GameObject Heroi;
    public Animator Animador;
    public GameObject dropPrefab;
    public GameObject CartolaPrefab;

    private void Start()
    {
        hpMax = hp;
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (ativo)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, pontoDestino.position, Time.deltaTime * 5);
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Atk"))
        {
            /*int rand = Random.Range(danoCuspe, danoCartola + 1);
            AplicarDano(rand);*/
        }
        if (other.CompareTag("Carta"))  // Mudança aqui para verificar "Carta" em vez de "Atk"
        {
            BulletControl bullet = other.GetComponent<BulletControl>();
            if (bullet != null)
            {
                AplicarDano(bullet.dano);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Atk")
        {
            int rand = Random.Range(danoCuspe, danoCartola + 1);
            AplicarDano(rand);
            Destroy(collision.gameObject);
        }
    }

    public void Disparo()
    {
        GameObject Tiro = Instantiate(Cuspe, PontoDeOrigem.transform.position, Quaternion.identity);
        Destroy(Tiro, 3f);

        if (transform.localScale.x == -1)
        {
            Tiro.GetComponent<AtaqueDistancia>().MudaVelocidade(-5);
        }
    }

    void AtaqueAleatorio()
    {
        DesativarAnimacoes();

        int ataqueSelecionado = Random.Range(0, 3);

        switch (ataqueSelecionado)
        {
            case 0:
                Cuspir();
                break;
            case 1:
                Avancar();
                break;
            case 2:
                LancarCartola();
                break;
            default:
                break;
        }

    }

    void DesativarAnimacoes()
    {
        Animador.SetBool("Cuspir", false);
        Animador.SetBool("Avancar", false);
        Animador.SetBool("LancarCartola", false);
        //desativa animações do modo vermelho
        Animador.SetBool("CuspirV", false);
        Animador.SetBool("AvancarV", false);
        Animador.SetBool("LancarCartolaV", false);
    }

    void Cuspir()
    {
        Animador.SetBool("Cuspir", true);
    }

    void Avancar()
    {
        Animador.SetBool("Avancar", true);
    }

    void LancarCartola()
    {
        Animador.SetBool("LancarCartola", true);
    }
    void CuspirV()
    {
        Animador.SetBool("CuspirV", true);
    }
    void AvancarV()
    {
        Animador.SetBool("AvancarV", true);
    }
    void LancarCartolaV()
    {
        Animador.SetBool("LancarCartolaV", true);
    }
    public void BossAp()
    {
        Animador.SetTrigger("BossAP");
    }
    void AtaqueAleatorioV()
    {
        DesativarAnimacoes();
        int ataqueSelecionado = Random.Range(0, 3);

        switch (ataqueSelecionado)
        {
            case 0:
                CuspirV();
                break;
            case 1:
                AvancarV();
                break;
            case 2:
                LancarCartolaV();
                break;
            default:
                break;
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

        if (hp <= 75)
        {
            Animador.SetTrigger("MetadeHP");
        }
        if (hp <= 0)
        {
            Animador.SetTrigger("Morrer");
            Morrer();
        }
       
    }

    public void AtivarBoss()
    {
        InvokeRepeating("AtaqueAleatorio", 2f, 3f);
        ativo = true;
    }
}