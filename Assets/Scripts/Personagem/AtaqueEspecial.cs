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
        if (other.CompareTag("Inimigo"))
        {
            
            ColetarAlma();
            
            other.GetComponent<Inimigo>().AplicarDano(ObterDanoAtual());
            
        }
    }

    void ColetarAlma()
    {
        almasColetadas++;
        if (almasColetadas >= almasNecessariasNivel1)
        {
            AtivarAtaqueEspecial();
        }
        /*else if (almasColetadas >= almasNecessariasNivel2)
        {
            AtivarAtaqueEspecialNivel2();
        }*/
    }

    int ObterDanoAtual()
    {
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

    /*void AtivarAtaqueEspecialNivel2()
    {
        // Lança a fissura à frente do impacto
        Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
        almasColetadas = 0;
    }*/
}

