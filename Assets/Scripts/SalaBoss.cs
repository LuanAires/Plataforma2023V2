using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBoss : MonoBehaviour
{
    public Animator Animation;
    public GameObject Parede;
    public AudioClip Impacto; 
    private AudioSource audioSource; 
    void Start()
    {
        // Inicialize o AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Adicione o componente se não estiver presente
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Atribua o áudio ao AudioSource
        audioSource.clip = Impacto;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Ative a parede
            Parede.SetActive(true);
            Debug.Log("Chegou");
            // Reproduza o áudio
            if (audioSource != null && Impacto != null)
            {
                audioSource.Play();
            }
            // Destrua este objeto
            Destroy(gameObject);
        }
    }
}
