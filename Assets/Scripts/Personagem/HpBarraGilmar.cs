using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarraGilmar : MonoBehaviour
{
    public Gilmar gilmar;
    
    
    [SerializeField] private float lifeMultiplier;
    [SerializeField] private float manaMultiplier;
    public Image BarraVerde;
    public Image BarraAzul;

    void Update()
    {
        AtualizarBarraDeVida();
        AtualizarBarraDeMana();
    }
    void AtualizarBarraDeVida()
    {
        BarraVerde.fillAmount = (float)gilmar.currentylife /(float) gilmar.maxLife;
    }
    void AtualizarBarraDeMana()
    {
        BarraAzul.fillAmount = (float)gilmar.currentyMana / (float) gilmar.maxMana;
        Debug.Log((float)gilmar.currentyMana / (float)gilmar.maxMana);
    }
}