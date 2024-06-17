using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public int dano = 10; // Valor do dano causado pela carta
    [SerializeField] public float velocidade_bala = 0.2f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if (other.CompareTag("inimigo"))
        {
            CabecaBoss boss = other.GetComponent<CabecaBoss>();
            if (boss != null)
            {
                boss.AplicarDano(dano);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        MoverBala();
    }

    void MoverBala()
    {
        transform.position = new Vector3(transform.position.x + velocidade_bala, transform.position.y, transform.position.z);
    }

    public void DiracaoBala(float direcao)
    {
        velocidade_bala = direcao;
    }
}

