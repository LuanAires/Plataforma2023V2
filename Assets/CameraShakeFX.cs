using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeFX : MonoBehaviour
{
    private GatilhoFechar gatilhoFechar;
    private CameraShake shake;

    // Start is called before the first frame update
    void Start()
    {
        //gatilhoFechar = GetComponent<GatilhoFechar>();
        shake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartShake()
    {
        shake.StartShake();
    }
    
}
