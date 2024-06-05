using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarraGilmar : MonoBehaviour
{
    public int maxlife;
    public int currentylife;
    public int maxMana;
    public int currentmana;
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
        BarraVerde.fillAmount = (float)currentylife / maxlife;
    }
    void AtualizarBarraDeMana()
    {
        BarraAzul.fillAmount = (float)currentmana / maxMana;
    }
    public void UsarMana(int quantidade)
    {
        currentmana -= quantidade;
        if (currentmana < 0) currentmana = 0;
        AtualizarBarraDeMana();
    }
    public void RecuperarMana(int quantidade)
    {
        currentmana += quantidade;
        if (currentmana > maxMana) currentmana = maxMana;
        AtualizarBarraDeMana();
    }
}