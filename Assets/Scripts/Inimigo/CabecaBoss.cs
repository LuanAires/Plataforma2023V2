using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabecaBoss : MonoBehaviour
{
    [SerializeField] Image imgBossLife;
    public bool ativo = false;

    [SerializeField] Transform pontoOrigem;
    [SerializeField] Transform pontoDestino;

    [SerializeField] public SalaBoss gatilho;
    public int hp = 1;
    private int hpMax;
    public GameObject CuspePrefab;
    public GameObject PontoDeOrigem;
    public int danoCuspe =10;
    public int danoAvanco =20 ;
    public int danoCartola = 15;
    public float velocidadeAvanco = 5f;
    public GameObject Heroi;
    public Animator Animador;
    public GameObject dropPrefab;
    public GameObject CartolaPrefab;
    //audio\\
    public AudioSource avanco;
    public AudioSource cuspe;
    public AudioSource risada;

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
            if (hp <= 500)
            {
                Animador.SetBool("MetadeHp", true);
            }
            if (hp <= 0)
            {
                Animador.SetBool("Morrer", true);
                Morrer();
            }

            imgBossLife.fillAmount = (float)hp / (float)hpMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Atk"))
        {
            AplicarDano(20);
        }

        if (other.CompareTag("Carta"))
        {
            BulletControl bullet = other.GetComponent<BulletControl>();
            if (bullet != null)
            {
                AplicarDano(bullet.dano);
                Destroy(other.gameObject);
            }
        }

        // Lógica para aplicar dano ao jogador
        if (other.CompareTag("Player"))
        {
            Gilmar playerGilmar = other.GetComponent<Gilmar>();
            if (playerGilmar != null)
            {
                playerGilmar.PerderHp(danoAvanco);  
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        if (collision.gameObject.CompareTag("Atk"))
        {
            /*BulletControl bullet = collision.gameObject.GetComponent<BulletControl>();
            if (bullet != null)
            {
                AplicarDano(bullet.dano);
                Destroy(collision.gameObject);
            }*/
            AplicarDano(100);
        }
        // dano ao jogador\\
        if (collision.gameObject.tag == "Player")
        {
            Gilmar playerGilmar = collision.gameObject.GetComponent<Gilmar>();
            if (playerGilmar != null)
            {
                playerGilmar.PerderHp(danoAvanco);  
            }
        }
    }

    public void Disparo()
    {
        GameObject Tiro = Instantiate(CuspePrefab, PontoDeOrigem.transform.position, Quaternion.identity);
        Vector3 direction = (Heroi.transform.position - Tiro.transform.position).normalized;
        Tiro.GetComponent<AtaqueDistanciaBoss>().MudaVelocidade(direction);
        Destroy(Tiro, 3f);
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
                DesativarAnimacoes();
                //Avancar();
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
        avanco.Play();
        Animador.SetBool("Avancar", true);
    }

    void LancarCartola()
    {
        Animador.SetBool("LancarCartola", true);
        //GameObject Cartola = Instantiate(CartolaPrefab, transform.position, Quaternion.identity);
        //Vector3 direction = (Heroi.transform.position - Cartola.transform.position).normalized;
        //Cartola.GetComponent<CartolaControl>().SetDirection(direction);
        //Destroy(Cartola, 3f);
    }

    void CuspirV()
    {
        Animador.SetBool("CuspirV", true);
    }

    void AvancarV()
    {
        avanco.Play();
        Animador.SetBool("AvancarV", true);
    }

    void LancarCartolaV()
    {
        Animador.SetBool("LancarCartolaV", true);
    }

    public void BossAp()
    {
        risada.Play();
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
        Animador.SetTrigger("Morrer");

        //Destroy(gameObject);
    }

    void DroparAlma()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }

    public void AplicarDano(int dano)
    {
        hp -= dano;

    }

    public void AtivarBoss()
    {
        InvokeRepeating("AtaqueAleatorio", 2f, 3f);
        ativo = true;
    }
}
