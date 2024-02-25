using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int hp = 1;
    public GameObject Espada;
    public GameObject Heroi;
    public Animator Animador;
    public GameObject almaPrefab; // Prefab da alma que será dropada

    private void Start()
    {
        Heroi = GameObject.FindGameObjectWithTag("Player");
        Animador = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(Heroi.transform.position, transform.position) < 5)
        {
            Animador.SetTrigger("Proximo");
        }
    }

    public void AtivaEspada()
    {
        Espada.SetActive(true);
    }

    public void DesativaEspada()
    {
        Espada.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D tocar)
    {
        if (tocar.gameObject.tag == "Atk")
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        // Acessa o componente de VidaInimigo e aplica dano suficiente para matar o inimigo
        GetComponent<VidaInimigo>().AplicarDano(GetComponent<VidaInimigo>().vidaInicial);
    }
}
