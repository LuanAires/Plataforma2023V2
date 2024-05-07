using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabecaBoss : MonoBehaviour
{
    public int hp = 1;
    private int hpMax;
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
        //Animador = GetComponent<Animator>();

        // Iniciar um ataque aleatório quando o chefe é iniciado
        InvokeRepeating("AtaqueAleatorio", 2f, 3f);
    }

    private void Update()
    {
        Animador.SetFloat("hp", hp);
        // Se necessário, você pode adicionar lógica de movimento ou comportamento aqui
    }

    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            int rand = Random.Range(danoCuspe, danoCartola + 1);
            AplicarDano(rand);
        }
    }

    void Cuspir()
    {
        Animador.SetBool("cuspe", true);
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
        Animador.SetBool("cuspe", true);
    }

    void AvancarV()
    {
        Animador.SetBool("Avancar", true);
    }

    void LancarCartolaV()
    {
        Animador.SetBool("LancarCartola", true);
    }


    void AtaqueAleatorio()
    {
        // Escolhe aleatoriamente um ataque para executar
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
    void AtaqueAleatorioV()
    {
        // Escolhe aleatoriamente um ataque para executar
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

        if (hp <= 0)
        {
            Animador.SetTrigger("Morrer");
            Morrer();
        }
    }
}
