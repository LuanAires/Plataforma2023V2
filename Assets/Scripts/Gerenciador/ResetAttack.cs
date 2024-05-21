using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAttack : MonoBehaviour
{

    private Gilmar gilmar;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gilmar= GetComponentInParent<Gilmar>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResetAtk()
    {
        anim.SetBool("Disparo", false);
    }

}
