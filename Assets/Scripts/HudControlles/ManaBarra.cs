using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarra : MonoBehaviour
{
    public int maxMana;
    public int currentyMana;
    [SerializeField] private float multiplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(currentyMana * multiplier / maxMana, 1, 1);
    }
}

