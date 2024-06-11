using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaBoss : MonoBehaviour
{
    [SerializeField] CabecaBoss boss;
    public Animator Animation;
    public GameObject Parede;
    public GameObject HpBarraBoss;
    public AudioClip ImpactoPilastra;
    public CinemachineVirtualCamera vmCam;
    [SerializeField]private AudioSource audioSource; 
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
        audioSource.clip = ImpactoPilastra;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Ative a parede
            Parede.SetActive(true);
            HpBarraBoss.SetActive(true);

            //Pega o componente camerashake e inicia o tremilique da camera
            vmCam.GetComponent<CameraShake>().StartShake();
            
            // Reproduza o áudio
            if (audioSource != null && ImpactoPilastra != null)
            {
                audioSource.Play();
            }

            boss.BossAp();

            // Destrua este objeto
            Destroy(gameObject);
        }
    }
}
