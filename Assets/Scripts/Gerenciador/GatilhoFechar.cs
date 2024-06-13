using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoFechar : MonoBehaviour
{
    [SerializeField] GameObject Grades;
    public Animator animator;
    [SerializeField] private AudioSource portaFechando;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portaFechando.Play();
            animator.SetBool("isOpen", false);
        }
    }
}
