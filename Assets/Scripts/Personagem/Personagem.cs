using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    private Rigidbody2D Corpo;
    [SerializeField] private Animator Animador;
    public int qtd_pulos = 2;
    public float velExtra = 0;
    //Ataque Distancia
    public GameObject Carta;
    public GameObject PontoDeOrigem;
    //Ataque Perto
    public GameObject Alma;
    //Quantidade de Sangue
    public int hp = 10;
    private Vector3 originalScale;

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
            originalScale = transform.localScale;
            AtaqueDistancia();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pular();
        }

        Debug.Log(qtd_pulos);
    }
    void AtaqueDistancia()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Disparo();
            Animador.SetTrigger("Disparo");
        }
    }
    public void Disparo()
    {
        GameObject Tiro = Instantiate(Carta, PontoDeOrigem.transform.position, Quaternion.identity);
        Destroy(Tiro, 3f);

        if (transform.localScale.x == -1)
        {
            Tiro.GetComponent<AtaqueDistancia>().MudaVelocidade(-5);
        }
    }

    void Mover()
    {
        float velX = 0;
        if (Input.GetKey(KeyCode.A))
            velX = -1 * (4 + velExtra);
       
        else if (Input.GetKey(KeyCode.D))
            velX = 1 * (4 + velExtra);

        float vely = Corpo.velocity.y;
        Corpo.velocity = new Vector2(velX, vely);

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
            Corpo.AddForce(Vector3.up * 350);
            Animador.SetBool("Jump", true);
        }
        else
        {
            Animador.SetBool("Jump", false);
        }

        qtd_pulos--;
    }
    private void OnTriggerEnter2D(Collider2D tocou)
    {
        if (tocou.gameObject.tag == "Solo")
        {
            qtd_pulos = 2;
            Animador.SetBool("Jump", false);
        }
        if (tocou.gameObject.tag == "Atk_inimigo")
        {
            if (hp > 0)
            {

                Animador.SetTrigger("Dano");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        Debug.Log("Item coletado!");
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

    public void Morrer()
    {
        Destroy(this.gameObject);
    }
}
    
