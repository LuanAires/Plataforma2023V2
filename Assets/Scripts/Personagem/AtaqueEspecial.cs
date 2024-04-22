using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspecial : MonoBehaviour
{
    public int almasNecessariasNivel1 = 5; 
    public int almasNecessariasNivel2 = 10; 
    private int almasColetadas = 0; 
    public GameObject efeitoAtaqueEspecial; 
    public int danoDoAtaqueNivel1 = 50; 
    public int danoDoAtaqueNivel2 = 100; 
    public GameObject fissuraPrefab; 

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido � um inimigo
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

        // Verifica se o jogador coletou todas as almas necess�rias para cada n�vel
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
        // Retorna o dano atual com base no n�mero de almas coletadas
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
        // Lan�a a fissura � frente do impacto
        Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        almasColetadas = 0;
    }
}

