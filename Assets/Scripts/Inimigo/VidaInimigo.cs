using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int vidaInicial = 100; // Quantidade inicial de vida do inimigo
    public GameObject almaPrefab; // Prefab da alma que será dropada
    private int vidaAtual; // Vida atual do inimigo

    void Start()
    {
        vidaAtual = vidaInicial;
    }

    // Método para aplicar dano ao inimigo
    public void AplicarDano(int dano)
    {
        vidaAtual -= dano;

        // Verifica se o inimigo está morto
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    // Método para destruir o inimigo quando a vida chega a 0 e dropar uma alma
    void Morrer()
    {
        DroparAlma();
        Destroy(gameObject);
    }

    // Método para dropar uma alma quando o inimigo morrer
    void DroparAlma()
    {
        Instantiate(almaPrefab, transform.position, Quaternion.identity);
    }
}

