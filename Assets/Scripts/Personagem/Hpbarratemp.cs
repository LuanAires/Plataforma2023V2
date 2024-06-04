using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbarratemp : MonoBehaviour
{
    public int maxlife;
    public int currentylife;
    public int maxMana;
    public int currentmana;
    [SerializeField] private float lifeMultiplier;
    [SerializeField] private float manaMultiplier;
    public Slider barraDeVida;
    public Slider barraDeMana;

    void Update()
    {
        AtualizarBarraDeVida();
        AtualizarBarraDeMana();
    }
    void AtualizarBarraDeVida()
    {
        barraDeVida.value = (float)currentylife / maxlife;
    }
    void AtualizarBarraDeMana()
    {
        barraDeMana.value = (float)currentmana / maxMana;
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