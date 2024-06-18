using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspecial : MonoBehaviour
{
    public int almasNecessariasNivel1 = 5;
    public int almasNecessariasNivel2 = 10;
    private int almasColetadas = 0;
    public GameObject eAtaqueEspecial;
    public int danoDoAtaqueNivel1 = 50;
    public int danoDoAtaqueNivel2 = 100;
    public GameObject fissuraPrefab;
    public int custoManaNivel1 = 20;
    public int custoManaNivel2 = 40;
    private Gilmar barraDeMana;

    void Start()
    {
        barraDeMana = GetComponent<Gilmar>();
        if (barraDeMana == null)
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            ColetarAlma();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<Inimigo>().AplicarDano(ObterDanoAtual());
            print("deu dano");
        }
    }

    void ColetarAlma()
    {
        almasColetadas++;
        if (almasColetadas >= almasNecessariasNivel2 && barraDeMana.currentyMana >= custoManaNivel2)
        {
            AtivarAtaqueEspecialNivel2();
        }
        else if (almasColetadas >= almasNecessariasNivel1 && barraDeMana.currentyMana >= custoManaNivel1)
        {
            AtivarAtaqueEspecial();
        }
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
        if (barraDeMana.currentyMana >= custoManaNivel1)
        {
            Instantiate(eAtaqueEspecial, transform.position, Quaternion.identity);
            barraDeMana.UsarMana(custoManaNivel1);
            AplicarDanoAInimigos(danoDoAtaqueNivel1);
            almasColetadas = 0;
        }
    }

    void AtivarAtaqueEspecialNivel2()
    {
        if (barraDeMana.currentyMana >= custoManaNivel2)
        {
            Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
            barraDeMana.UsarMana(custoManaNivel2);
            AplicarDanoAInimigos(danoDoAtaqueNivel2);
            almasColetadas = 0;
        }
    }

    void AplicarDanoAInimigos(int dano)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, eAtaqueEspecial.transform.localScale.x);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Inimigo"))
            {
                collider.GetComponent<Inimigo>().AplicarDano(dano);
            }
        }
    }
}
