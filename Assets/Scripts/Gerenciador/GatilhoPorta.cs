using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoPorta : MonoBehaviour
{
    [SerializeField] GameObject GradesDaPorta;
    public Animator animator;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GradesDaPorta.SetActive(true);
            animator.SetBool("Transicao out", true);
        }
    }
}
