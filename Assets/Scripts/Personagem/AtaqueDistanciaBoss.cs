using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDistanciaBoss : MonoBehaviour
{
    private Rigidbody2D CorpoBala;
    Vector3 direcao;
    private float velocidade = 100;

    // Start is called before the first frame update
    void Start()
    {
        CorpoBala = GetComponent<Rigidbody2D>();
    }

    public void MudaVelocidade(Vector3 direcao)
    {
        this.direcao = direcao;
    }

    void Update()
    {
        CorpoBala.velocity = direcao * Time.deltaTime * velocidade;
    }
}
