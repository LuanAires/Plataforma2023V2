using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamadaTiro : MonoBehaviour
{

    [SerializeField] private Personagem person;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChamadaDisparo()
    { 
     person.Disparo();
    }
}
