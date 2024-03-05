using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspecial : MonoBehaviour
{
    public int almasNecessariasNivel1 = 5; // Quantidade de almas necessárias para ativar o ataque especial no nível 1
    public int almasNecessariasNivel2 = 10; // Quantidade de almas necessárias para ativar o ataque especial no nível 2
    private int almasColetadas = 0; // Quantidade de almas coletadas até o momento
    public GameObject efeitoAtaqueEspecial; // Efeito visual do ataque especial
    public int danoDoAtaqueNivel1 = 50; // Dano causado pelo ataque especial no nível 1
    public int danoDoAtaqueNivel2 = 100; // Dano causado pelo ataque especial no nível 2
    public GameObject fissuraPrefab; // Prefab da fissura

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido é um inimigo
        if (other.CompareTag("Inimigo"))
        {
            // Coleta a alma do inimigo
            ColetarAlma();
            // Aplica dano ao inimigo
            other.GetComponent<Inimigo>().AplicarDano(ObterDanoAtual());
            // Destroi o inimigo se a vida for menor ou igual a 0
        }
    }

    void ColetarAlma()
    {
        almasColetadas++;

        // Verifica se o jogador coletou todas as almas necessárias para cada nível
        if (almasColetadas >= almasNecessariasNivel1)
        {
            AtivarAtaqueEspecial();
        }
        else if (almasColetadas >= almasNecessariasNivel2)
        {
            AtivarAtaqueEspecialNivel2();
        }
    }

    int ObterDanoAtual()
    {
        // Retorna o dano atual com base no número de almas coletadas
        if (almasColetadas >= almasNecessariasNivel2)
        {
            return danoDoAtaqueNivel2;
        }
        else
        {
            return danoDoAtaqueNivel1;
        }
    }

    void AtivarAtaqueEspecial()
    {
        // Instantiate the special attack effect
        Instantiate(efeitoAtaqueEspecial, transform.position, Quaternion.identity);
      
        almasColetadas = 0;
    }

    void AtivarAtaqueEspecialNivel2()
    {
        // Lança a fissura à frente do impacto
        Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        almasColetadas = 0;
    }
}

