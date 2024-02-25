using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDistancia : MonoBehaviour
{
    private Rigidbody2D CorpoBala;
    private float ladoVelocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        CorpoBala = GetComponent<Rigidbody2D>();
    }

    public void MudaVelocidade(float direcao)
    {
        ladoVelocidade = direcao;
    }


    void Update()
    {
        CorpoBala.velocity = new Vector2(ladoVelocidade, 0);
    }
}
