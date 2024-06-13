using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatorController : MonoBehaviour
{
    CabecaBoss cabecaBoss;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cabecaBoss = GetComponentInParent<CabecaBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarCabecaBoss() 
    {
        cabecaBoss.AtivarBoss();
    }

}
