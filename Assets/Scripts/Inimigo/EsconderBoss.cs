using UnityEngine;

public class EsconderBoss : MonoBehaviour
{
    // Refer�ncia ao GameObject que queremos desativar
    public GameObject CorpoBoss;
    public GameObject CabecaBoss;

    void Start()
    {
        // Verifica se a refer�ncia ao GameObject foi configurada
        if (CorpoBoss != null)
        {
            // Desativa o GameObject
            CorpoBoss.SetActive(false);
        }

        // Verifica se a refer�ncia ao GameObject foi configurada
        if (CabecaBoss != null)
        {
            // Desativa o GameObject
            CabecaBoss.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Nenhum GameObject foi atribu�do para ser desativado.");
        }
    }

    // M�todo para desativar o GameObject manualmente
    public void Deactivate()
    {
        if (CabecaBoss != null)
        {
            CabecaBoss.SetActive(false);
        }
        if (CorpoBoss != null)
        {
            CorpoBoss.SetActive(false);
        }
    }
}
