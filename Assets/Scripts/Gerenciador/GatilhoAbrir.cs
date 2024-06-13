using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoAbrir : MonoBehaviour
{
    [SerializeField] GameObject Grades;
    public Animator animator;
    [SerializeField] private AudioSource portaAbrindo;
    [SerializeField] private AudioSource portaFechando;

    void Start()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Grades.SetActive(true);
            portaAbrindo.Play();
            animator.SetBool("isOpen", true);
        }
    }
}
