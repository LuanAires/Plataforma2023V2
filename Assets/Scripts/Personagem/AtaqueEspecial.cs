using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspecial : MonoBehaviour
{
    public int almasNecessariasNivel1 = 5;
    public int almasNecessariasNivel2 = 5;
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
            Debug.LogError("Gilmar component not found on the same GameObject as AtaqueEspecial.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            ColetarAlma();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<Inimigo>().AplicarDano(ObterDanoAtual());
            print("deudano");
        }
    }

    void ColetarAlma()
    {
        almasColetadas++;
        if (almasColetadas >= almasNecessariasNivel1 && barraDeMana.currentyMana >= custoManaNivel1)
        {
            AtivarAtaqueEspecial();
        }
       /* else if (almasColetadas >= almasNecessariasNivel2 && barraDeMana.currentyMana >= custoManaNivel2)
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
        if (barraDeMana.currentyMana >= custoManaNivel1)
        {
            Instantiate(eAtaqueEspecial, transform.position, Quaternion.identity);
            barraDeMana.UsarMana(custoManaNivel1);
            almasColetadas = 0;
            AplicarDanoAInimigos(danoDoAtaqueNivel1);
        }
    }

    /*void AtivarAtaqueEspecialNivel2()
    {
        if (barraDeMana.currentyMana >= custoManaNivel2)
        {
            Instantiate(fissuraPrefab, transform.position + transform.forward * 2, Quaternion.identity);
            barraDeMana.UsarMana(custoManaNivel2);
            almasColetadas = 0;
            AplicarDanoAInimigos(danoDoAtaqueNivel2);
        }
    }*/

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