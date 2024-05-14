using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private float velocidade_bala = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
