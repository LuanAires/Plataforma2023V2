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
    public int custoManaNivel1 = 20;
    public int custoManaNivel2 = 40;
    private HpBarraGilmar barraDeVidaMana;

    void Start()
    {
        barraDeVidaMana = GetComponent<HpBarraGilmar>();
        if (barraDeVidaMana == null)
        {
            Debug.LogError("HpBarraGilmar script is missing on the player!");
        }
    }

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
        if (almasColetadas >= almasNecessariasNivel1 && barraDeVidaMana.currentmana >= custoManaNivel1)
        {
            AtivarAtaqueEspecial();
        }
        /*else if (almasColetadas >= almasNecessariasNivel2 && barraDeVidaMana.currentmana >= custoManaNivel2)
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
        if (barraDeVidaMana.currentmana >= custoManaNivel1)
        {
            Instantiate(efeitoAtaqueEspecial, transform.position, Quaternion.identity);
            barraDeVidaMana.UsarMana(custoManaNivel1); // Deduz o custo de mana usando o m�todo da HpBarraGilmar
            almasColetadas = 0;
        }
    }

    /*void AtivarAtaqueEspecialNivel2()
    {
        if (barraDeVidaMana.currentmana >= custoManaNivel2)
        {
            // Lan�a a fissura � frente do impacto
            Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
            barraDeVidaMana.UsarMana(custoManaNivel2); // Deduz o custo de mana usando o m�todo da HpBarraGilmar
            almasColetadas = 0;
        }
    }*/
}

