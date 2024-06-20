using UnityEngine;

public class EsconderBoss : MonoBehaviour
{
    // Referência ao GameObject que queremos desativar
    public GameObject CorpoBoss;
    public GameObject CabecaBoss;

    void Start()
    {
        // Verifica se a referência ao GameObject foi configurada
        if (CorpoBoss != null)
        {
            // Desativa o GameObject
            CorpoBoss.SetActive(false);
        }

        // Verifica se a referência ao GameObject foi configurada
        if (CabecaBoss != null)
        {
            // Desativa o GameObject
            CabecaBoss.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Nenhum GameObject foi atribuído para ser desativado.");
        }
    }

    // Método para desativar o GameObject manualmente
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
